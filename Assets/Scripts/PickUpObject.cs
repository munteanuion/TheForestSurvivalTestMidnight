using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform _arm;

    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void PickUp()
    {
        if(_arm.childCount < 2)
        {
            transform.SetParent(_arm);
            transform.position = _arm.position;
            transform.rotation = _arm.rotation;
            _rigidbody.isKinematic = true;
            _boxCollider.isTrigger = true;
        }
    }
}
