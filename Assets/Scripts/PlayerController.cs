using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float xVelocity = 5f;   // amount to add to X when left-clicking

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            AddXVelocity();
        }
    }

    private void AddXVelocity()
    {
        Vector2 v = rb.velocity;
        v.x += xVelocity;          // use = xVelocity; if you want a fixed speed instead
        rb.velocity = v;
    }
}
