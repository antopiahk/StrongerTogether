using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    GameObject player1Backhand;
    GameObject player1Fronthand;
    GameObject player2Backhand;
    GameObject player2Fronthand;
    LineRenderer lR;

    void Start()
    {
        player1Backhand = GameObject.Find("PlayerOne").transform.Find("Hands").gameObject.transform.Find("Back hand").gameObject;
        player2Backhand = GameObject.Find("PlayerTwo").transform.Find("Hands").gameObject.transform.Find("Back hand").gameObject;
        player1Fronthand = GameObject.Find("PlayerOne").transform.Find("Hands").gameObject.transform.Find("Hand pivot").gameObject.transform.Find("Hand").gameObject;
        player2Fronthand = GameObject.Find("PlayerTwo").transform.Find("Hands").gameObject.transform.Find("Hand pivot").gameObject.transform.Find("Hand").gameObject;
        lR = GetComponent<LineRenderer>();
        lR.positionCount = 4;
    }


    void Update()
    {
        lR.SetPosition(0, player1Backhand.transform.position + new Vector3(0, 0.03125f, 0));
        lR.SetPosition(1, player1Fronthand.transform.position + new Vector3(0, 0.03125f, 0));
        lR.SetPosition(2, player2Fronthand.transform.position + new Vector3(0, 0.03125f, 0));
        lR.SetPosition(3, player2Backhand.transform.position + new Vector3(0, 0.03125f, 0));
    }
}
