using UnityEngine;

public class UFOController : MonoBehaviour
{
    [SerializeField] private Transform body;      // сюда в инспекторе перетащи объект UFO
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 120f;

    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");   // W/S
        float h = Input.GetAxisRaw("Horizontal"); // A/D

        // Движение вперёд/назад + влево/вправо относительно КОРПУСА
        Vector3 moveDir = (body.forward * v + body.right * h).normalized;
        body.position += moveDir * moveSpeed * Time.deltaTime;

        // Поворот корпуса по горизонтали (если нужен)
        if (Mathf.Abs(h) > 0.001f)
        {
            float turn = h * rotationSpeed * Time.deltaTime;
            body.Rotate(0f, turn, 0f, Space.World);
        }
    }
}