using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform _arm;

    private Rigidbody _rigidbody;
    private MeshCollider _meshCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshCollider = GetComponent<MeshCollider>();
    }

    public void PickUp()
    {
        if(_arm.childCount < 2)
        {
            transform.SetParent(_arm);
            transform.position = _arm.position;
            transform.rotation = _arm.rotation;
            _rigidbody.isKinematic = true;
            _meshCollider.isTrigger = true;
            _meshCollider.enabled = false;
        }
    }
}
