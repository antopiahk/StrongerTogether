using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.instance.GameOver(collider.gameObject);
    }
}
