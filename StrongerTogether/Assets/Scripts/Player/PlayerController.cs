using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timeToFullyChargeJump = 1;
    public float jumpForce = 3;
    public float chargePercent;
    public float horizontalSpeed = 3;
    public float maxHorizontalSpeed = 3;
    public bool isGrounded;
    float timeElapsed;
    float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            timeElapsed += Time.deltaTime;
            chargePercent = Mathf.Clamp(timeElapsed / timeToFullyChargeJump, 0, 1);
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce * chargePercent, ForceMode2D.Impulse);
            timeElapsed = 0;
            chargePercent = 0;
        }

        //Steering
        horizontal = Input.GetAxis("Horizontal");
        float horizontalVelocity = rb.velocity.x;
        rb.velocity = new Vector2(Mathf.Clamp(horizontalVelocity, -maxHorizontalSpeed, maxHorizontalSpeed), rb.velocity.y);
    }

    private void FixedUpdate()
    {
        //Steering
        if (!isGrounded)
        {
            rb.AddForce(Vector2.right * horizontal * horizontalSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
