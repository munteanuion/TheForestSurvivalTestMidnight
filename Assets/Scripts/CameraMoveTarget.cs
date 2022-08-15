using UnityEngine;

public class CameraMoveTarget : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _minimumAngle = 75;
    [SerializeField] private float _maximumAngle = 350;
    [SerializeField] private float _mouseSensitivity = 0.8f;
    [SerializeField] private bool _stickCamera;

    private float _aimX;
    private float _aimY;
    private Vector3 _vector3Empty;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        _aimX = Input.GetAxis("Mouse X");
        _aimY = Input.GetAxis("Mouse Y");

        _cameraTarget.rotation *= Quaternion.AngleAxis(_aimX * _mouseSensitivity, Vector3.up);
        _cameraTarget.rotation *= Quaternion.AngleAxis(-_aimY * _mouseSensitivity, Vector3.right);
        
        _aimX = _cameraTarget.localEulerAngles.x;

        if (_aimX > 180 && _aimX < _maximumAngle)
        {
            _aimX = _maximumAngle;
        }
        else if (_aimX < 180 && _aimX > _minimumAngle)
        {
            _aimX = _minimumAngle;
        }
        
        _vector3Empty.Set(_aimX, _cameraTarget.localEulerAngles.y, 0);
        _cameraTarget.localEulerAngles = _vector3Empty;

        if (_stickCamera)
        {
            _playerModel.rotation = Quaternion.Euler(0, _cameraTarget.rotation.eulerAngles.y, 0);
        }
    }

    public bool HasStickCamera()
    {
        return _stickCamera;
    }
}
