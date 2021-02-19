using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2Controller : MonoBehaviour
{
    public GameObject surprisedEmote;
    public float emoteDuration;
    Player2Controller playerScript;
    Animator playerAnim;
    Animator handsAnim;
    bool emoting;

    void Start()
    {
        playerScript = GetComponent<Player2Controller>();
        playerAnim = GetComponent<Animator>();
        handsAnim = transform.Find("Hands").gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && playerScript.isGrounded && playerScript.chargePercent > 0.1f)
        {
            playerAnim.SetBool("Jumping", true);
        }

        playerAnim.SetFloat("HeldFor", playerScript.chargePercent);

        playerAnim.SetFloat("Vertical", playerScript.rb.velocity.y);

        playerAnim.SetBool("isGrounded", playerScript.isGrounded);

        if (Input.GetKeyDown(KeyCode.DownArrow) && playerScript.isGrounded && !emoting)
        {
            playerAnim.SetTrigger("Surprised");
            StartCoroutine(Emote(surprisedEmote));
            emoting = true;
        }

        if (Input.GetKeyDown(KeyCode.Period) && playerScript.pullIsReady)
        {
            handsAnim.SetTrigger("Pull");
        }
    }

    public IEnumerator Emote(GameObject emote)
    {
        GameObject thisEmote = Instantiate(emote, playerScript.rb.position + new Vector2(-0.5f, 0.8125f), transform.rotation);
        yield return new WaitForSeconds(emoteDuration);
        Destroy(thisEmote);
        emoting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("Jumping", false);
        }
    }
}
