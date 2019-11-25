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

    public AudioClip menuSound;

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
            audioSource.PlayOneShot(menuSound);
        }
    }

    /// <summary>
    /// Dummy function to start the Play co-routine.
    /// </summary>
    void play()
    {
        StartCoroutine(play(3.0f));
    }

    IEnumerator play(float fadeOutDuration)
    {
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
