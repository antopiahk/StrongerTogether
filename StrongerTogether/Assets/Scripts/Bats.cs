using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D collider;
    Vector2 destination;
    Vector2 dir;
    GameObject player;
    Animator batAnim;
    Animator batPullAnim;
    PlayerController player1Script;
    Player2Controller player2Script;
    LineRenderer rope;
    public bool isAlive;
    public float timeToRotate;
    public int whichBat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        batAnim = transform.Find("Sprite").gameObject.GetComponent<Animator>();
        batPullAnim = GetComponent<Animator>();
    }


    void Update()
    {
        if (isAlive)
        {
            //Moves bat towards its position also sets the line renderer position
            if (player.name == "PlayerOne")
            {
                destination = new Vector2(player.transform.position.x - (0.5f * (whichBat)), player.transform.position.y);
                dir = (destination - (Vector2)transform.position).normalized;
                //0.2 is so that it doesnt have to move to the exact spot
                if (dir.magnitude > 0.2)
                {
                    rb.velocity = dir;
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
                rope.SetPosition(whichBat, transform.position);
                if (Input.GetKeyDown(KeyCode.V) && player1Script.pullIsReady)
                {
                    batPullAnim.SetTrigger("Pull");
                }
            }
            //same but for player 2
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
                if (Input.GetKeyDown(KeyCode.Period) && player2Script.pullIsReady)
                {
                    batPullAnim.SetTrigger("Pull");
                }
            }
        }
    }

    void FixedUpdate()
    {
        //max speed limit
        if(rb.velocity.magnitude > 2.5f)
        {
            rb.velocity = rb.velocity.normalized*2.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Makes it go through rope
            gameObject.layer = 3;
            player = collision.gameObject;
            //Find out which player it bumped into and increases the num of bats
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
                transform.localScale = new Vector3(-1, 1, 1);
            }
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            //ignores some tingies
            Physics2D.IgnoreCollision(collider, collision.gameObject.GetComponent<BoxCollider2D>(), true);
            Physics2D.IgnoreLayerCollision(3, 6, true);
            Physics2D.IgnoreLayerCollision(3, 7, true);
            Physics2D.IgnoreLayerCollision(3, 3, true);
            //turns on the follow functions in Update
            isAlive = true;
            //Turns it upright slowly
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
