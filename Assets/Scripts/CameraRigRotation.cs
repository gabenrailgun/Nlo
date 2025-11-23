using UnityEngine;

public class CameraFollowTO : MonoBehaviour
{
    public Transform ufoBody;
    public Transform turret;

    public float height = 4f;       // поднял выше
    public float distance = 8f;     // дальше отодвинул

    public float rotateSpeed = 150f;

    public float minFov = 45f;
    public float maxFov = 75f;
    public float zoomSpeed = 20f;

    private float cameraYaw = 0f;

    void Start()
    {
        if (turret != null)
            cameraYaw = turret.eulerAngles.y;

        Camera.main.fieldOfView = 60f;
    }

    void LateUpdate()
    {
        if (ufoBody == null || turret == null)
            return;

        // ZOOM
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.0001f)
        {
            Camera.main.fieldOfView -= scroll * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFov, maxFov);
        }

        // Вращение по ПКМ (как в Танках)
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            cameraYaw += mouseX * rotateSpeed * Time.deltaTime;
        }
        else
        {
            // Следуем за пушкой
            float turretYaw = turret.eulerAngles.y;
            cameraYaw = Mathf.LerpAngle(cameraYaw, turretYaw, Time.deltaTime * 8f);
        }

        // Позиция камеры
        Vector3 offset = Quaternion.Euler(0, cameraYaw, 0) * new Vector3(0, height, -distance);
        transform.position = ufoBody.position + offset;

        // Камера смотрит туда же, куда пушка
        transform.LookAt(ufoBody.position + Vector3.up * 2f);
    }
}