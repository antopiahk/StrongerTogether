using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D collider;
    public bool isAlive;
    public float timeToRotate;
    GameObject player;
    Animator batAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        batAnim = transform.Find("Sprite").gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            Physics2D.IgnoreCollision(collider, collision.gameObject.GetComponent<BoxCollider2D>(), true);
            player = collision.gameObject;
            isAlive = true;
            batAnim.SetBool("isAlive", isAlive);
            StartCoroutine(LerpRotation(rb.rotation));
        }
    }

    IEnumerator LerpRotation(float initialRotation)
    {
        float time = 0;
        while (time < timeToRotate)
        {
            rb.rotation = Mathf.Lerp(initialRotation, 0, time / timeToRotate);
            time += Time.deltaTime;
            yield return null;
        }
        rb.rotation = 0;
    }
}
