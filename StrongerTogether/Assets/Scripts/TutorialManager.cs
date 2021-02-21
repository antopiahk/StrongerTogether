using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    public enum TutorialStage
    {
        WELCOME,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,


    }

    public TutorialStage tutorialStage = TutorialStage.WELCOME;
    public TextMeshProUGUI tutorialText;

    public void Start()
    {
        WelcomeText();
    }
    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            switch (tutorialStage)
            {
                case TutorialStage.WELCOME:
                    PlayerControlsTextFirst();
                    break;
                case TutorialStage.ONE:
                    PlayerControlsTextSecond();
                    break;
                case TutorialStage.TWO:
                    PlayerControlsTextThird();
                    break;
                case TutorialStage.THREE:
                    PullingRopeText();
                    break;
                case TutorialStage.FOUR:
                    PlatformsText();
                    break;
                case TutorialStage.FIVE:
                    ExtraJumpsText();
                    break;
                case TutorialStage.SIX:
                    BatsText();
                    break;
                case TutorialStage.SEVEN:
                    LavaText();
                    break;
                case TutorialStage.EIGHT:
                    TrialRunText();
                    break;
                case TutorialStage.NINE:
                    tutorialText.text = "Ready...";
                    Invoke("Play", 3);
                    break;

            }


        }
    }
    public void WelcomeText()
    {
        tutorialStage = TutorialStage.WELCOME;
        tutorialText.text = "Hold W / Down-Arrow and release to jump. Left click to continue.";
    }

    public void PlayerControlsTextFirst()
    {
        tutorialStage = TutorialStage.ONE;
        tutorialText.text = "A/D Left-Arrow/Right-Arrow to strafe mid-air";
    }
    public void PlayerControlsTextSecond()
    {
        tutorialStage = TutorialStage.TWO;
        tutorialText.text = "The goal of the game is to stay away from the lava and survive longer than your friends.";
    }
    public void PlayerControlsTextThird()
    {
        tutorialStage = TutorialStage.THREE;
        tutorialText.text = "Press 'v' or '.' to tug on the rope.You can use this to mess up your opponents jumping direction and make him fall.";
    }

    public void PullingRopeText()
    {
        tutorialStage = TutorialStage.FOUR;
        tutorialText.text = "The cooldowns are shown on the bars on the sides! The tugging right now is very weak...";
    }
    public void PlatformsText()
    {
        tutorialStage = TutorialStage.FIVE;
        tutorialText.text = "Platforms are the most common spawns in the air. They allow you to jump from under and land on top! Try jumping on the one above you!";
    }

    public void ExtraJumpsText()
    {
        tutorialStage = TutorialStage.SIX;
        tutorialText.text = "The red arrows are extra jumps. Hitting them will give you an extra boost as you jump!";
    }

    public void BatsText()
    {
        tutorialStage = TutorialStage.SEVEN;
        tutorialText.text = "Bats are essential in that they help you out when you tug on the rope by adding more force!" +
        " Bats are in the shape of balls when they spawn, and will roll to whoever is lower, giving them a slight advantage with pulling power. More bats = more pulling force";
    }

    public void LavaText()
    {
        tutorialStage = TutorialStage.EIGHT;
        tutorialText.text = "Tugging while your friends are in the air is more effective, so keep your eyes on your friends too!";
    }

    public void TrialRunText()
    {
        tutorialStage = TutorialStage.NINE;
        tutorialText.text = "Now that you know the controls, try everything out with a few trial round." +
                            " Click To Start! The camera moves up FYI";
    }
    public void Play()
    {
        tutorialText.text = "Go!";
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().waitTime = 0;
        Invoke("ClearText",1);
    }

    public void ClearText()
    {
         tutorialText.text = "";
    }

}
