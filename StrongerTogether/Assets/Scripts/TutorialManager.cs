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
        tutorialText.text = "Welcome to Our Game!";
    }

    public void PlayerControlsTextFirst()
    {
        tutorialStage = TutorialStage.ONE;
        tutorialText.text = "Press W / Down-Arrow to jump";
    }
    public void PlayerControlsTextSecond()
    {
        tutorialStage = TutorialStage.TWO;
        tutorialText.text = "Moving sideways is only allowed during the air and predetermined the second before your jump.";
    }
    public void PlayerControlsTextThird()
    {
        tutorialStage = TutorialStage.THREE;
        tutorialText.text = "You can move with 'A' and 'D' or '<-' and '->'. Try it out!";
    }

    public void PullingRopeText()
    {
        tutorialStage = TutorialStage.FOUR;
        tutorialText.text = "Press 'v' or '.' to tug on the rope. You can use this to mess up your opponents jumping direction and make him fall." +
                            " The cooldowns are shown on the bars on the sides! The tugging right now is very weak...";
    }
    public void PlatformsText()
    {
        tutorialStage = TutorialStage.FIVE;
        tutorialText.text = "Platforms are the most common spawns in the air. They allow you to jump from under and land on top! Try jumping on the one above you!";
    }

    public void ExtraJumpsText()
    {
        tutorialStage = TutorialStage.SIX;
        tutorialText.text = "The red arrows are extra jumps. Hitting them will give you an extra boost as you jump, or save you from falling!";
    }

    public void BatsText()
    {
        tutorialStage = TutorialStage.SEVEN;
        tutorialText.text = "Bats are essential in that they help you out when you tug on the rope by adding more force!" +
        " A bats are in the shape of aballs when they spawn, and will roll to whoever is lower, giving them a slight advantage with pulling power. More bats = more pulling force";
    }

    public void LavaText()
    {
        tutorialStage = TutorialStage.EIGHT;
        tutorialText.text = "LAVA. Just don't let it touch you... :/ And yeah, don't fall into the big hole in the middle";
    }

    public void TrialRunText()
    {
        tutorialStage = TutorialStage.NINE;
        tutorialText.text = "Now that you know the controls, try everything out with a few trial rounds. Just so that you don't get destroyed in the first real round." +
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
