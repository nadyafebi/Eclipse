using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string startSceneName;
    public string creditSceneName;

    public Button playButton;
    public Button creditsButton;
    public Button quitButton;

    public Image fadeOut;

    public AudioClip menuSelect;

    public AudioClip menuClick;

    private AudioSource audioSource;

    private AudioManager audioManager;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

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
    /// Dummy function to start the showCredits coroutine.
    /// </summary>
    void showCredits()
    {
        StartCoroutine(showCredits(1.0f));
    }

    /// <summary>
    /// Dummy function to start the quit coroutine.
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
        yield return audioManager.FadeAudio(fadeOutDuration);
        
        SceneManager.LoadScene(startSceneName);
    }

    IEnumerator showCredits(float fadeOutDuration)
    {
        audioSource.PlayOneShot(menuClick);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, fadeOutDuration, false);

        // Fade the audio too.
        yield return audioManager.FadeAudio(fadeOutDuration);
        
        SceneManager.LoadScene(creditSceneName);
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
        Application.Quit();
        # endif
    }
}
