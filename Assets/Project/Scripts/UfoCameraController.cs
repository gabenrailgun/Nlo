using UnityEngine;

public class UfoCameraController : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private Transform ufoBody;
    [SerializeField] private Transform turret;

    [Header("Position")]
    [SerializeField] private float height = 4f;
    [SerializeField] private float distance = 8f;

    [Header("Rotation")]
    [SerializeField] private float rotateSpeed = 150f;
    [SerializeField] private float followLerpSpeed = 8f;

    [Header("Zoom")]
    [SerializeField] private float minFov = 45f;
    [SerializeField] private float maxFov = 75f;
    [SerializeField] private float zoomSpeed = 20f;
    [SerializeField] private float startFov = 60f;

    private Camera _camera;
    private float _yaw;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _yaw = turret.eulerAngles.y;
        
        _camera.fieldOfView = startFov;
    }

    private void LateUpdate()
    {
        HandleZoom();
        HandleRotation();
        UpdatePosition();
        LookAtTarget();
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) < 0.0001f) return;

        float fov = _camera.fieldOfView - scroll * zoomSpeed;
        _camera.fieldOfView = Mathf.Clamp(fov, minFov, maxFov);
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            _yaw += mouseX * rotateSpeed * Time.deltaTime;
        }
        else if (turret != null)
        {
            float turretYaw = turret.eulerAngles.y;
            _yaw = Mathf.LerpAngle(_yaw, turretYaw, Time.deltaTime * followLerpSpeed);
        }
    }

    private void UpdatePosition()
    {
        Vector3 offset = Quaternion.Euler(0f, _yaw, 0f) * new Vector3(0f, height, -distance);
        transform.position = ufoBody.position + offset;
    }

    private void LookAtTarget()
    {
        transform.LookAt(ufoBody.position + Vector3.up * 2f);
    }
}
