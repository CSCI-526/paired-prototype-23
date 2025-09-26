using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSlingshotControl : MonoBehaviour
{
    [Header("Slingshot Settings")]
    public float forceMultiplier = 0.05f; // adjust strength of launch

    private Rigidbody2D rb;
    private Vector3 dragStartPos;
    private bool isDragging = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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

            rb.velocity = launchVelocity;

            isDragging = false;
        }
    }
}
