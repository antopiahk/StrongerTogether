using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PlayerOne" || collider.name == "PlayerTwo")
        {
            GameManager.instance.GameOver(collider.gameObject);
        }
    }
}
