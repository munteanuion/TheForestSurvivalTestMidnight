using UnityEditor;
using UnityEngine;

public class PlayerPickUpObject : MonoBehaviour
{
    [SerializeField] private float _distanceRaycast = 4f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _textE;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _arm;

    private const string WEAPON_NAME_TAG = "Weapon";
    private RaycastHit _hit;
    private Inventory _inventory;
    private GameObject _slotButton;
    private int _indexObjectInHand;


    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (_textE.activeSelf)
        {
            _textE.SetActive(false);
        }

        PickUpObject();
        DropObject();
        ChangeObjectFromInventory();
    }


    private void DropObject()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _arm.childCount > 0 && _inventory.GetPrefabByIndex(_indexObjectInHand) != null)
        {
            _inventory.GetPrefabByIndex(_indexObjectInHand).GetComponent<PickUpObject>().DropDownObject();
            _inventory.DeletePrefabByIndex(_indexObjectInHand);
            _inventory.isFull[_indexObjectInHand] = false;

            Transform transformTemp = _inventory.slotsTargetCanvas[_indexObjectInHand].transform;

            transformTemp = transformTemp.GetChild(transformTemp.childCount - 1);

            transformTemp.SetParent(null);

            Destroy(transformTemp.gameObject);
        }
    }

    private void PickUpObject()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _distanceRaycast, _layerMask))
        {
            if (_hit.collider.tag == WEAPON_NAME_TAG)
                _textE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
                for (int i = 0; i < _inventory.slotsTargetCanvas.Length; i++)
                    if (_inventory.isFull[i] == false)
                    {
                        _hit.collider.GetComponent<PickUpObject>().PickUp(_arm, _inventory.GetPrefabByIndex(_indexObjectInHand));
                        _indexObjectInHand = i;
                        _inventory.isFull[i] = true;
                        _inventory.AddPrefabInSlot(_hit.collider.gameObject, i);
                        Instantiate(
                            _hit.collider.gameObject.GetComponent<WeaponStats>().GetInventoryIconPrefab(), 
                            _inventory.slotsTargetCanvas[i].transform);
                        break;
                    }
        }
    }

    private void ChangeObjectFromInventory()
    {
        ChangeObjectHelpMethod(Input.GetKeyDown(KeyCode.Alpha1), 0);
        ChangeObjectHelpMethod(Input.GetKeyDown(KeyCode.Alpha2), 1);
        ChangeObjectHelpMethod(Input.GetKeyDown(KeyCode.Alpha3), 2);
    }

    private void ChangeObjectHelpMethod(bool isTrue,int index) 
    {
        if (isTrue && _inventory.isFull[index] && _indexObjectInHand != index)
        {
            if(_inventory.GetPrefabByIndex(_indexObjectInHand) != null)
                if (_arm.childCount > 0 && _inventory.GetPrefabByIndex(_indexObjectInHand).activeSelf)
                    _inventory.GetPrefabByIndex(_indexObjectInHand).SetActive(false);

            _inventory.GetPrefabByIndex(index).SetActive(true);
            _indexObjectInHand = index;

            for (int i = 0; i < _inventory.GetLenghtGameObjectsInSlots(); i++)
            {
                _inventory.GetPrefabByIndex(i).GetComponent<PickUpObject>().isPicked = false;
            }
            _inventory.GetPrefabByIndex(index).GetComponent<PickUpObject>().isPicked = true;
        }
    }
}
