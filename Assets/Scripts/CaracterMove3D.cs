using UnityEngine;

public class CaracterMove3D : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Transform _playerModel; 
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _mainCamera;
    
    private Rigidbody _rigidbody;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _animator.SetFloat("HorizontalSpeed", horizontal); 
        _animator.SetFloat("VerticalSpeed", vertical); 

        Vector3 camForward = _mainCamera.forward;
        Vector3 camRight = _mainCamera.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 movingVector = horizontal * camRight.normalized + vertical * camForward.normalized;

        if (!_mainCamera.GetComponent<CameraMoveTarget>().HasStickCamera()) 
        {
            if (movingVector.magnitude >= 0.2f)
            {
                _playerModel.rotation = Quaternion.LookRotation(camForward, Vector3.up);
            }
        }

        //_rigidbody.velocity = movingVector * _speed;
        _rigidbody.MovePosition(transform.position + movingVector * _speed * Time.fixedDeltaTime);

        if (_rigidbody.velocity.magnitude > _speed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
    }
}
