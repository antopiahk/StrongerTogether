using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullBarUI : MonoBehaviour
{
    public Slider pullSlider;
    public Slider jumpSlider;
    public GameObject jumpUI;
    PlayerController player1Script;
    Player2Controller player2Script;

    void Start()
    {
        if (gameObject.name == "PlayerOne")
        {
            player1Script = GetComponent<PlayerController>();
        }
        if (gameObject.name == "PlayerTwo")
        {
            player2Script = GetComponent<Player2Controller>();
        }
    }

    void Update()
    {
        if (gameObject.name == "PlayerOne")
        {
            pullSlider.value = player1Script.pullCharge / player1Script.pullCoolDown;
            jumpSlider.value = player1Script.chargePercent;
            if (player1Script.chargePercent != 0)
            {
                jumpUI.SetActive(true);
            }
            else
            {
                jumpUI.SetActive(false);
            }
        }
        if (gameObject.name == "PlayerTwo")
        {
            pullSlider.value = player2Script.pullCharge / player2Script.pullCoolDown;
            jumpSlider.value = player2Script.chargePercent;
            if (player2Script.chargePercent != 0)
            {
                jumpUI.SetActive(true);
            }
            else
            {
                jumpUI.SetActive(false);
            }
        }

        jumpUI.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3 (0, 40, 0);
    }
}
