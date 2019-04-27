using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 100;
    [SerializeField] float decelerationRate = .95f;
    [SerializeField] float jumpForce = 1000f;
    [SerializeField] bool hasAirControl = false;

    Rigidbody2D rb;

    Vector2 movement = Vector2.zero;

    [SerializeField] CollisionChecker groundChecker;
    bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        groundChecker.onCollidingUpdated.AddListener(UpdateGrounded);
    }

    void UpdateGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    // Move if grounded
    public void Move(float x)
    {
        if (isGrounded || hasAirControl)
        {
            movement.x = x * speed * Time.deltaTime;
            rb.AddForce(movement);
        }
    }

    public void Jump()
    {
        if (isGrounded) {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") == 0 && isGrounded)
        {
            // Apply Deceleration
            Vector2 velocity = rb.velocity;
            velocity.x *= decelerationRate * Time.deltaTime;
            rb.velocity = velocity;
        }
    }
}
