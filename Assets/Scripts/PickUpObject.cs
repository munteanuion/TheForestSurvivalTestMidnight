using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform _arm;
    [SerializeField] private float _speedDropObject = 2;

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
        if (_arm.childCount < 1)
        {
            transform.parent = null;
            _rigidbody.isKinematic = false;
            _boxCollider.isTrigger = false;
            _boxCollider.enabled = true;
            _rigidbody.AddForce(transform.forward * _speedDropObject);
        }
    }
}
