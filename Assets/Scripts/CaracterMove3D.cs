using UnityEngine;

public class CaracterMove3D : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform _playerModel; 
    [SerializeField] private Animator _animator;

    private Transform _mainCamera;
    private Rigidbody _rigidbody;
   
    void Start()
    {
        _mainCamera = Camera.main.transform;
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

        _rigidbody.velocity = movingVector * speed;
    }
}
