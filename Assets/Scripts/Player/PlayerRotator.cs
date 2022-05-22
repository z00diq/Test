using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Camera _camera;
    [SerializeField] [Range(0, 360)] private float _maxRotateAngle;
    [SerializeField] [Range(0, 360)] private float _minRotateAngle;

    private float _mouseRotationX;
    private float _mouseRotationY;

    private Vector3 _horizontalRotate;
    private Vector3 _verticalRotate;

    private enum Axis
    {
        MouseX,
        MouseY
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseRotationX = Input.GetAxis(Axis.MouseX.ToString());
        _mouseRotationY = -Input.GetAxis(Axis.MouseY.ToString());
        
        _horizontalRotate = new Vector3(0, _mouseRotationX, 0)*_rotationSpeed;
        _verticalRotate = new Vector3(_mouseRotationY, 0, 0) * _rotationSpeed;

        float targetRotationX = (_camera.transform.rotation.eulerAngles + _verticalRotate).x;

        if (targetRotationX >= _maxRotateAngle || targetRotationX <= _minRotateAngle)
            _camera.transform.Rotate(_verticalRotate);
  
        transform.Rotate(_horizontalRotate);
    }
}
