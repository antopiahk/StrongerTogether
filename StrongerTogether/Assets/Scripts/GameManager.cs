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
        if (Input.GetKeyUp(KeyCode.R))
        {
            Reset();
        }
    }

    public void GameOver(GameObject loser)
    {

        if (loser == playerOne)
        {
            winner = playerTwo;
        }
        else if (loser == playerTwo)
        {
            winner = playerOne;
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
