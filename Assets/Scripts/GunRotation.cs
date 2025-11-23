using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float rotationSpeed = 150f;

    private float yaw = 0f;
    private Quaternion baseRotation;

    void Start()
    {
        baseRotation = transform.localRotation;
    }

    void Update()
    {
        // ПКМ зажата — пушка не вертится
        if (Input.GetMouseButton(1))
            return;

        float mouseX = Input.GetAxis("Mouse X");
        yaw += mouseX * rotationSpeed * Time.deltaTime;

        // ВРАЩЕНИЕ ВДОЛЬ ОСИ Z !!!
        transform.localRotation = baseRotation * Quaternion.Euler(0f, 0f, yaw);
    }
}