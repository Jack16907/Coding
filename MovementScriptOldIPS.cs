using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // "Horizontal" works for A/D, Arrows, AND Gamepad Joysticks
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = moveInput * speed;

        // "Jump" is a default Unity name mapped to Space AND Gamepad South (A/Cross)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocityY = jumpForce;
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
