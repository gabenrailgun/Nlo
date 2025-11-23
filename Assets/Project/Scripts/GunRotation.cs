using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float smoothTime = 0.05f;  

    private Quaternion _baseRotation;
    private float _targetYaw;
    private float _currentYaw;
    private float _yawVelocity;

    private void Awake()
    {
        _baseRotation = transform.rotation;
        _currentYaw = 0f;
        _targetYaw = 0f;
    }

    private void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            _targetYaw += mouseX * rotationSpeed * Time.deltaTime;
        }
        
        _currentYaw = Mathf.SmoothDampAngle(
            _currentYaw,
            _targetYaw,
            ref _yawVelocity,
            smoothTime
        );

        transform.rotation = _baseRotation * Quaternion.Euler(0f, _currentYaw, 0f);
    }
}