using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public string LunaSceneName;
    public string SolSceneName;
    public string BothSceneName;

    public Button LunaButton;
    public Button SolButton;
    public Button BothButton;

    public Image fadeOut;

    public AudioClip menuSelect;

    public AudioClip menuClick;

    private AudioSource audioSource;

    private AudioManager audioManager;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = GameManager.GetAudioManager();

        LunaButton.onClick.AddListener(Luna);
        SolButton.onClick.AddListener(Sol);
        BothButton.onClick.AddListener(Both);
    }

    void Update()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            audioSource.PlayOneShot(menuSelect);
        }
    }

    /// <summary>
    /// Dummy function to start the play coroutine.
    /// </summary>
    void Luna()
    {
        StartCoroutine(Luna(0.5f));
    }

    /// <summary>
    /// Dummy function to start the showCredits coroutine.
    /// </summary>
    void Sol()
    {
        StartCoroutine(Sol(0.5f));
    }

    /// <summary>
    /// Dummy function to start the quit coroutine.
    /// </summary>
    void Both()
    {
        StartCoroutine(Both(0.5f));
    }

    IEnumerator Luna(float fadeOutDuration)
    {
        audioSource.PlayOneShot(menuClick);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, fadeOutDuration, false);

        // Fade the audio too.
        yield return audioManager.FadeAudio(fadeOutDuration);
        
        SceneManager.LoadScene(LunaSceneName);
    }

    IEnumerator Sol(float fadeOutDuration)
    {
        audioSource.PlayOneShot(menuClick);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, fadeOutDuration, false);

        // Fade the audio too.
        yield return audioManager.FadeAudio(fadeOutDuration);
        
        SceneManager.LoadScene(SolSceneName);
    }

    IEnumerator Both(float fadeOutDuration)
    {
        audioSource.PlayOneShot(menuClick);

        // Fade the screen to black.
        fadeOut.color = Color.black;
        fadeOut.canvasRenderer.SetAlpha(0.0f);
        fadeOut.CrossFadeAlpha(1.0f, fadeOutDuration, false);

        // Fade the audio too.
        yield return audioManager.FadeAudio(fadeOutDuration);
        
        SceneManager.LoadScene(BothSceneName);
    }
}
