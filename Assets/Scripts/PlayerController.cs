using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSlingshotControl : MonoBehaviour
{
    [Header("Slingshot Settings")]
    public float forceMultiplier = 0.05f; // adjust strength of launch
    public float maxSpeed = 100f;          // clamp upper speed
    public float dragSpeed = .1f;
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
        Vector2 dragAmount = new Vector2(dragSpeed, 0f);
        rb.velocity -= dragAmount;
        if (Input.GetMouseButtonDown(0)) // start drag
        {
            dragStartPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // release drag
        {
            Vector3 dragEndPos = Input.mousePosition;
            Vector3 dragDelta = dragEndPos - dragStartPos;

            // Opposite direction for slingshot
            Vector2 launchVelocity = new Vector2(-dragDelta.x, -dragDelta.y) * forceMultiplier;

            // Clamp speed between 0 and maxSpeed
            if (launchVelocity.magnitude > maxSpeed)
                launchVelocity = launchVelocity.normalized * maxSpeed;

            rb.velocity += launchVelocity;

            isDragging = false;
        }
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0f, maxXSpeed), rb.velocity.y);
    }
}
