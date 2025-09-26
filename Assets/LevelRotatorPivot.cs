using UnityEngine;

public class LevelRotatorPivot : MonoBehaviour
{
    [Header("References")]
    public Transform player;       // assign player
    public Vector3 offset;         // offset from player

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
        // Move pivot to player's position + offset
        transform.position = player.position + offset;

        // Timer for direction switching
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            targetRotation = (targetRotation > 0) ? -maxRotation : maxRotation;
            timer = changeInterval;
        }

        // Smoothly rotate pivot (which rotates the whole level around player)
        float newZ = Mathf.LerpAngle(transform.eulerAngles.z, targetRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }
}
