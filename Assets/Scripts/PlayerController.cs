using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Slingshot Settings")]
    public float forceMultiplier = .05f;
    public float maxSpeed = 100f;
    public float airResistence = .01f;
    public float maxXSpeed = 100f;

    private Rigidbody2D rb;
    private Vector3 dragStartPos;
    private bool isDragging = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dragAmount = new Vector2(airResistence, 0f);
        rb.velocity -= dragAmount;
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector3 dragEndPos = Input.mousePosition;
            Vector3 dragDelta = dragEndPos - dragStartPos;

            Vector2 launchVelocity = new Vector2(-dragDelta.x, -dragDelta.y) * forceMultiplier;

            if (launchVelocity.magnitude > maxSpeed)
                launchVelocity = launchVelocity.normalized * maxSpeed;

            rb.velocity += launchVelocity;

            isDragging = false;
        }
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0f, maxXSpeed), rb.velocity.y);
    }
}
