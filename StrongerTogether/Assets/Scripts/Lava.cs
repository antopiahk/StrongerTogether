using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private bool gameOver = false;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PlayerOne" || collider.name == "PlayerTwo")
        {
            if (!gameOver)
            {
                GameManager.instance.GameOver(collider.gameObject);
                gameOver = true;
            }
        }
        if (collider.CompareTag("Platform"))
        {
            Destroy(collider.gameObject);
        }
    }
}
