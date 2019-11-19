using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToNextScene : MonoBehaviour
{

    public string gameSceneName;
    public GameObject sunPlayer;
    public GameObject moonPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(moonPlayer.GetComponent<Collider2D>())
            || GetComponent<BoxCollider2D>().IsTouching(sunPlayer.GetComponent<Collider2D>()))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }
}
