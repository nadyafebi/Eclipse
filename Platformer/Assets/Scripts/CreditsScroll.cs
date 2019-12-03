using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    public string startMenuScene;
    public float duration = 10.0f;
    public Image fadeOut;

    // Start is called before the first frame update
    void Start()
    {
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

        SceneManager.LoadScene(startMenuScene);
    }
}
