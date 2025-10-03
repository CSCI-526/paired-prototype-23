using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target;

    [Header("Camera Settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;

        transform.position = new Vector3(transform.position.x, transform.position.y, -16.7f);
    }
}
