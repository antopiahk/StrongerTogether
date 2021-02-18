using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    Transform player1Backhand;
    Transform player1Fronthand;
    Transform player2Backhand;
    Transform player2Fronthand;
    LineRenderer lR;

    void Start()
    {
        player1Backhand = GameObject.Find("Player").transform.Find("Hands").transform.Find("Back hand");
        player2Backhand = GameObject.Find("Player2").transform.Find("Hands").transform.Find("Back hand");
        player1Fronthand = GameObject.Find("Player").transform.Find("Hands").transform.Find("Hand pivot").transform.Find("Hand");
        player2Fronthand = GameObject.Find("Player2").transform.Find("Hands").transform.Find("Hand pivot").transform.Find("Hand");
        lR = GetComponent<LineRenderer>();
        lR.positionCount = 4;
    }


    void Update()
    {
        lR.SetPosition(0, player1Backhand.position);
        lR.SetPosition(1, player1Fronthand.position);
        lR.SetPosition(2, player2Fronthand.position);
        lR.SetPosition(3, player2Backhand.position);
    }
}
