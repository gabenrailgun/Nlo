using UnityEngine;

public class GunPivotFollower : MonoBehaviour
{
    public Transform ufoBody;
    public Vector3 offset = new Vector3(0f, 1f, 0f); // высота пушки

    void LateUpdate()
    {
        if (ufoBody != null)
            transform.position = ufoBody.position + offset;
    }
}