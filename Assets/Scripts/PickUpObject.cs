using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform _arm;

    private float _speedDropObject = 200;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void PickUp()
    {
        if(_arm.childCount < 1)
        {
            transform.SetParent(_arm);
            transform.position = _arm.position;
            transform.rotation = _arm.rotation;
            _rigidbody.isKinematic = true;
            _boxCollider.isTrigger = true;
            _boxCollider.enabled = false;
        }
    }

    public void DropDownObject()
    {
        _rigidbody.isKinematic = false;
        _boxCollider.enabled = true;
        _boxCollider.isTrigger = false;
        _rigidbody.AddForce(transform.forward * _speedDropObject);
        transform.parent = null;
    }
}
