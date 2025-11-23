using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 120f;

    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * forward * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * rotationSpeed * Time.deltaTime);
    }
}