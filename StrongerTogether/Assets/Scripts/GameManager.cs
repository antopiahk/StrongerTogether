using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerOne, playerTwo;
    public CameraShake cameraShake;
    public GameObject gameOverGUI;

    private GameObject winner;

    public float generalVelocity;

    public TextMeshProUGUI playerOneScoreText, playerTwoScoreText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
    }
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            Reset();
        }
        playerOneScoreText.text = DataManager.instance.playerOneScore.ToString();
        playerTwoScoreText.text = DataManager.instance.playerTwoScore.ToString();
    }

    public void GameOver(GameObject loser)
    {
        //StartCoroutine(GameManager.instance.cameraShake.Shake(.5f, 0.5f));
        if (loser = playerOne)
        {
            winner = playerTwo;
            DataManager.instance.playerTwoScore++;
        }
        else if (loser = playerTwo)
        {
            winner = playerOne;
            DataManager.instance.playerOneScore++;
        }
        gameOverGUI.SetActive(true);
        gameOverGUI.transform.Find("GameOverText").GetComponent<TextMeshProUGUI>().text = "Player " + winner.name[6] + winner.name[7] + winner.name[8] + " Wins!";
        StopAllCoroutines();
    }


    public void Reset()
    {
        DataManager.instance.playerOneScore = 0;
        DataManager.instance.playerTwoScore = 0;
        Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
