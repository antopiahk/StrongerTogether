using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject surprisedEmote;
    public float emoteDuration;
    PlayerController playerScript;
    Animator playerAnim;
    bool emoting;

    void Start()
    {
        playerScript = GetComponent<PlayerController>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && playerScript.isGrounded && playerScript.chargePercent > 0.1f)
        {
            playerAnim.SetBool("Jumping", true);
        }

        playerAnim.SetFloat("HeldFor", playerScript.chargePercent);

        playerAnim.SetFloat("Vertical", playerScript.rb.velocity.y);

        playerAnim.SetBool("isGrounded", playerScript.isGrounded);

        if (Input.GetKeyDown(KeyCode.E) && playerScript.isGrounded && !emoting)
        {
            playerAnim.SetTrigger("Surprised");
            StartCoroutine(Emote(surprisedEmote));
            emoting = true;
        }
    }

    public IEnumerator Emote(GameObject emote)
    {
        GameObject thisEmote = Instantiate(emote, playerScript.rb.position + new Vector2(0.5f, 0.8125f), transform.rotation);
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
