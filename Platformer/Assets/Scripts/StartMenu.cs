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

    public Image fadeOut;

    public AudioClip menuSelect;

    public AudioClip menuClick;

    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playButton.onClick.AddListener(play);
        creditsButton.onClick.AddListener(showCredits);
        quitButton.onClick.AddListener(quit);
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            audioSource.PlayOneShot(menuSelect);
        }
    }

    /// <summary>
    /// Dummy function to start the play coroutine.
    /// </summary>
    void play()
    {
        StartCoroutine(play(3.0f));
    }

    /// <summary>
    /// Dummy function to start the play coroutine.
    /// </summary>
    void quit()
    {
        StartCoroutine(quit(1.0f));
    }

    IEnumerator play(float fadeOutDuration)
    {
        audioSource.PlayOneShot(menuClick);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, fadeOutDuration, false);

        // Fade the audio too.
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }
        
        SceneManager.LoadScene("Stage 1.1 Spawn");
    }

    void showCredits()
    {
        audioSource.PlayOneShot(menuClick);
    }

    IEnumerator quit(float fadeOutDuration)
    {
        audioSource.PlayOneShot(menuClick);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, fadeOutDuration, false);

        yield return new WaitForSeconds(fadeOutDuration);

        # if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        # else
        Application.quit();
        # endif
    }
}
