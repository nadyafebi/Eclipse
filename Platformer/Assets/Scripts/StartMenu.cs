using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button quitButton;
    
    void Start()
    {
        playButton.onClick.AddListener(play);
        creditsButton.onClick.AddListener(showCredits);
        quitButton.onClick.AddListener(quit);
    }

    void play()
    {
        // TODO: Insert some cool transition here!
        SceneManager.LoadScene("Stage 1.1 Spawn");
    }

    void showCredits()
    {

    }

    void quit()
    {
        # if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        # else
        Application.quit();
        # endif
    }
}
