using UnityEngine;

public class LevelRotator : MonoBehaviour
{
    [Header("References")]
    public Transform player;       // assign your player here
    public Vector3 offset;         // optional offset from player

    [Header("Rotation Settings")]
    public float maxRotation = 10f;
    public float rotationSpeed = 2f;
    public float changeInterval = 3f;

    private float targetRotation;
    private float timer;

    void Start()
    {
        targetRotation = Random.Range(0, 2) == 0 ? -maxRotation : maxRotation;
        timer = changeInterval;
    }

    void Update()
    {
        // world position of rotation pivot
        Vector3 pivotPoint = player.position + offset;

        // countdown for direction switch
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            targetRotation = (targetRotation > 0) ? -maxRotation : maxRotation;
            timer = changeInterval;
        }

        // smoothly rotate towards target Z
        float newZ = Mathf.LerpAngle(transform.eulerAngles.z, targetRotation, Time.deltaTime * rotationSpeed);

        // apply rotation around player (with offset)
        transform.RotateAround(pivotPoint, Vector3.forward, newZ - transform.eulerAngles.z);
    }
}
