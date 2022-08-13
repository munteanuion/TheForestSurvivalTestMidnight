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

    private void FixedUpdate()
    {
        if (_textE.activeSelf)
        {
            _textE.SetActive(false);
        }

        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _distanceRaycast, _layerMask))
        {
            if(_hit.collider.tag == WEAPON_NAME_TAG)
            {
                _textE.SetActive(true);
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.collider.GetComponent<PickUpObject>().PickUp();
            } 
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _arm.gameObject.GetComponentInChildren<PickUpObject>().DropDownObject();
        }
    }
}
