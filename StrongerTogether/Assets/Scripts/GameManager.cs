using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerOne, playerTwo;
    public GameObject gameOverGUI;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
    }

    public void GameOver(GameObject loser)
    {
        Debug.Log("WINNER");
        gameOverGUI.SetActive(true);
        gameOverGUI.transform.Find("GameOverText").GetComponent<TextMeshProUGUI>().text = "Player " + loser.name[6]+loser.name[7]+loser.name[8] + " Wins!";
        StopAllCoroutines();
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
