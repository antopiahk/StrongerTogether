using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToBatsRope : MonoBehaviour
{
    LineRenderer lR;
    PlayerController playerScript;
    Player2Controller player2Script;
    GameObject player1Backhand;
    GameObject player2Backhand;

    void Start()
    {
        lR = GetComponent<LineRenderer>();
        playerScript = GameObject.Find("PlayerOne").GetComponent<PlayerController>();
        player2Script = GameObject.Find("PlayerTwo").GetComponent<Player2Controller>();
        player1Backhand = GameObject.Find("PlayerOne").transform.Find("Hands").gameObject.transform.Find("Back hand").gameObject;
        player2Backhand = GameObject.Find("PlayerTwo").transform.Find("Hands").gameObject.transform.Find("Back hand").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == ("Player1Rope")) 
        {
            lR.positionCount = 1 + playerScript.numOfBats;
            lR.SetPosition(0, player1Backhand.transform.position);
        }
        if (this.name == ("Player2Rope"))
        {
            lR.positionCount = 1 + player2Script.numOfBats;
            lR.SetPosition(0, player2Backhand.transform.position);
        }
    }
}
