using UnityEngine;

public class CaracterMove3D : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] public float _runSpeed = 10f; // Viteza de deplasare cand personajul fuge
    [SerializeField] public float _animSpeed = 1f; // Viteza de animatie a personajului cand merge
    [SerializeField] public float _runAnimSpeed = 2f; // Viteza de animatie a personajului cand fuge
    [SerializeField] private Transform _playerModel; 
    [SerializeField] private Transform _mainCamera;

    private float _defaultAnimSpeed; // Viteza de animatie default a personajului
    private bool _isRunning = false; // Verifica daca personajul fuge sau nu
    private float _horizontal;
    private float _vertical;
    private bool _hasStickCamera;
    private Vector3 _vector3Empty1;
    private Vector3 _vector3Empty2;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private PlayerHealth _playerHealth;
    private const string ATTACK1_NAME_ANIMATOR = "AttackTwoHand", BLOCK_NAME_ANIMATOR = "Block";

    private void Awake()
    {
        _hasStickCamera = _mainCamera.GetComponent<CameraMoveTarget>().HasStickCamera();
        _rigidbody = GetComponent<Rigidbody>();
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _defaultAnimSpeed = GetComponent<Animator>().speed;
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
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _animator.SetFloat("HorizontalSpeed", _horizontal);
        _animator.SetFloat("VerticalSpeed", _vertical);

        _vector3Empty1 = _mainCamera.forward;
        _vector3Empty2 = _mainCamera.right;

        _vector3Empty1.y = 0f;
        _vector3Empty2.y = 0f;

        _vector3Empty2 = _horizontal * _vector3Empty2.normalized + _vertical * _vector3Empty1.normalized;

        if (!_hasStickCamera && _vector3Empty2.magnitude >= 0.2f)
            _playerModel.rotation = Quaternion.LookRotation(_vector3Empty1, Vector3.up);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }

        float speedToMove = _speed;

        if (_isRunning)
        {
            _animSpeed = _runAnimSpeed;
            speedToMove = _runSpeed;
        }
        else
        {
            _animSpeed = _defaultAnimSpeed;
            speedToMove = _speed;
        }

        _rigidbody.MovePosition(transform.position + _vector3Empty2 * speedToMove * Time.fixedDeltaTime);

        if (_rigidbody.velocity.magnitude > speedToMove)
            _rigidbody.velocity = _rigidbody.velocity.normalized * speedToMove;

        GetComponent<Animator>().speed = _animSpeed;
    }
}
