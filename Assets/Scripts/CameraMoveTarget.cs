using UnityEngine;

public class CameraMoveTarget : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private float _minimumAngle = 75;
    [SerializeField] private float _maximumAngle = 350;
    [SerializeField] private float _mouseSensitivity = 0.8f;
    [SerializeField] private bool _stickCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float aimX = Input.GetAxis("Mouse X");
        float aimY = Input.GetAxis("Mouse Y");
        _cameraTarget.rotation *= Quaternion.AngleAxis(aimX * _mouseSensitivity, Vector3.up);
        _cameraTarget.rotation *= Quaternion.AngleAxis(-aimY * _mouseSensitivity, Vector3.right);
        
        var angleX = _cameraTarget.localEulerAngles.x;

        if (angleX > 180 && angleX < _maximumAngle)
        {
            angleX = _maximumAngle;
        }
        else if (angleX < 180 && angleX > _minimumAngle)
        {
            angleX = _minimumAngle;
        }

        _cameraTarget.localEulerAngles = new Vector3(angleX, _cameraTarget.localEulerAngles.y, 0);

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
