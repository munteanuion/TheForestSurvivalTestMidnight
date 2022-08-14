using UnityEngine;

public class CaracterMove3D : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Transform _playerModel; 
    [SerializeField] private Transform _mainCamera;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    private PlayerHealth _playerHealth;
    private const string ATTACK1_NAME_ANIMATOR = "AttackTwoHand", BLOCK_NAME_ANIMATOR = "Block";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (
            _playerHealth.GetHealth() > 0 && 
            !_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK1_NAME_ANIMATOR) &&
            !_animator.GetCurrentAnimatorStateInfo(0).IsName(BLOCK_NAME_ANIMATOR)
            )
        {
            MoveRotatePlayer();
        }
    }

    private void MoveRotatePlayer()
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

        if (!_mainCamera.GetComponent<CameraMoveTarget>().HasStickCamera() && movingVector.magnitude >= 0.2f)
            _playerModel.rotation = Quaternion.LookRotation(camForward, Vector3.up);

        _rigidbody.MovePosition(transform.position + movingVector * _speed * Time.fixedDeltaTime);

        if (_rigidbody.velocity.magnitude > _speed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
    }
}
