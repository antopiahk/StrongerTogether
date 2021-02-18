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
    public bool pullIsReady;
    public float pullCharge;
    public float pullCoolDown = 5;
    public float pullForce = 2;
    float timeElapsed;
    float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Jumping
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            timeElapsed += Time.deltaTime;
            chargePercent = Mathf.Clamp(timeElapsed / timeToFullyChargeJump, 0, 1);
        }
        if (Input.GetKeyUp(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce * chargePercent, ForceMode2D.Impulse);
            timeElapsed = 0;
            chargePercent = 0;
        }

        //Pulling
        if (Input.GetKeyDown(KeyCode.V) && pullIsReady)
        {
            pullCharge = 0;
            pullIsReady = false;
            GameObject.Find("PlayerTwo").GetComponent<Rigidbody2D>().AddForce((transform.position - GameObject.Find("PlayerTwo").transform.position).normalized * pullForce, ForceMode2D.Impulse);
        }
        pullCharge += Time.deltaTime;
        if(pullCharge / pullCoolDown >= 1)
        {
            pullIsReady = true;
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
