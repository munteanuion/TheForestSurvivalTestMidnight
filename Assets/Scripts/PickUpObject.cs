using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private float _speedDropObject = 200;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void PickUp(Transform _arm, GameObject gameObjectInventory)
    {
        if(gameObjectInventory != null)
            if (_arm.childCount > 0 && gameObjectInventory.activeSelf)
                gameObjectInventory.SetActive(false);

        transform.SetParent(_arm);
        transform.position = _arm.position;
        transform.rotation = _arm.rotation;
        _rigidbody.isKinematic = true;
        _boxCollider.isTrigger = true;
        _boxCollider.enabled = false;
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
