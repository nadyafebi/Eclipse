using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    public string startMenuScene;
    public string chooseEndingScene;
    public float duration = 10.0f;
    public Image fadeOut;
    public GameObject endingButton;
    public GameObject menuButton;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Get();
        StartCoroutine(fadeAway());
    }

    IEnumerator fadeAway()
    {
        yield return new WaitForSeconds(duration - 1.0f);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, 1.0f, false);

        yield return new WaitForSeconds(1.0f);

        if (gameManager.IsGameFinished())
        {
            endingButton.SetActive(true);
            menuButton.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(startMenuScene);
        }
    }

    public void ChooseAnotherEnding()
    {
        SceneManager.LoadScene(chooseEndingScene);
    }

    public void BackToStartMenu()
    {
        gameManager.SetGameFinished(false);
        SceneManager.LoadScene(startMenuScene);
    }
}
