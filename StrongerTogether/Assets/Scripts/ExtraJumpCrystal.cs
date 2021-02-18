using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJumpCrystal : MonoBehaviour
{
    bool isActive = true;
    public float jumpForce;
    public float respawnTime;
    public ParticleSystem breakEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isActive = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            breakEffect.Play();
            StartCoroutine(respawn());
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        isActive = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
