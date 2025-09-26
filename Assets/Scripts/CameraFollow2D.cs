using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target;  // Drag your Player here

    [Header("Camera Settings")]
    public float smoothSpeed = 5f;   // higher = snappier, lower = smoother
    public Vector3 offset;           // set this if you want the camera not exactly on the player

    void LateUpdate()
    {
        if (target == null) return;

        // desired camera position
        Vector3 desiredPosition = target.position + offset;

        // smooth movement
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        //transform.position = smoothedPosition;
        transform.position = target.position + offset;

        // lock z-axis (important for 2D)
        transform.position = new Vector3(transform.position.x, transform.position.y, -16.7f);
    }
}
