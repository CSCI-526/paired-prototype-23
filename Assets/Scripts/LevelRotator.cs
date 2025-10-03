using UnityEngine;

public class LevelRotator : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Vector3 offset;

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
        Vector3 pivotPoint = player.position + offset;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            targetRotation = (targetRotation > 0) ? -maxRotation : maxRotation;
            timer = changeInterval;
        }

        float newZ = Mathf.LerpAngle(transform.eulerAngles.z, targetRotation, Time.deltaTime * rotationSpeed);

        transform.RotateAround(pivotPoint, Vector3.forward, newZ - transform.eulerAngles.z);
    }
}
