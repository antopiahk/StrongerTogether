using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D collider;
    public bool isAlive;
    public float timeToRotate;
    Vector2 destination;
    Vector2 dir;
    GameObject player;
    Animator batAnim;
    PlayerController player1Script;
    Player2Controller player2Script;
    LineRenderer rope;
    public int whichBat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        batAnim = transform.Find("Sprite").gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (isAlive)
        {
            if(player.name == "PlayerOne")
            {
                destination = new Vector2(player.transform.position.x - (0.5f * (whichBat)), player.transform.position.y);
                dir = (destination - (Vector2)transform.position).normalized;
                if (dir.magnitude > 0.2)
                {
                    rb.velocity = dir;
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
                rope.SetPosition(whichBat, transform.position);
            }
            else if (player.name == "PlayerTwo")
            {
                destination = new Vector2(player.transform.position.x + (0.5f * (whichBat)), player.transform.position.y);
                dir = destination - (Vector2)transform.position;
                if (dir.magnitude > 0.1)
                {
                    rb.velocity = dir * 8 / Mathf.Sqrt(whichBat);
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
                rope.SetPosition(whichBat, transform.position);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.layer = 3;
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            if (player.name == "PlayerOne")
            {
                rope = GameObject.Find("Player1Rope").GetComponent<LineRenderer>();
                player1Script = player.GetComponent<PlayerController>();
                player1Script.numOfBats += 1;
                whichBat = player1Script.numOfBats;
            }
            else if (player.name == "PlayerTwo")
            {
                rope = GameObject.Find("Player2Rope").GetComponent<LineRenderer>();
                player2Script = player.GetComponent<Player2Controller>();
                player2Script.numOfBats += 1;
                whichBat = player2Script.numOfBats;
            }
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            Physics2D.IgnoreCollision(collider, collision.gameObject.GetComponent<BoxCollider2D>(), true);
            Physics2D.IgnoreLayerCollision(3, 6, true);
            Physics2D.IgnoreLayerCollision(3, 7, true);
            Physics2D.IgnoreLayerCollision(3, 3, true);
            isAlive = true;
            StartCoroutine(LerpRotation(transform.localEulerAngles.z));
        }
    }

    IEnumerator LerpRotation(float initialRotation)
    {
        float time = 0;
        while (time < timeToRotate)
        {
            yield return null;
            transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(initialRotation, 0, time / timeToRotate));
            time += Time.deltaTime;
        }
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        batAnim.SetBool("isAlive", isAlive);
    }
}
