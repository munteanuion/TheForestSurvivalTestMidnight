using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpObject : MonoBehaviour
{
    [SerializeField] private float _distanceRaycast = 4f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Text _textE;
    [SerializeField] private Transform _cameraTransform;

    private const string WEAPON_NAME_TAG = "Weapon";
    private RaycastHit _hit;

    private void FixedUpdate()
    {
        Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward, Color.green);
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _distanceRaycast, _layerMask))
        {
            if(_hit.collider.tag == WEAPON_NAME_TAG)
            {
                _textE.enabled = true;
            }
            else if(_textE.enabled == true)
            {
                //_textE.enabled = false;
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.collider.GetComponent<PickUpObject>().PickUp();
            }
                
        }
    }
}
