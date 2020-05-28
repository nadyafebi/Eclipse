using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the overall game logic.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Refers to the instace of managers. There can only be one!
    /// </summary>
    private static GameManager instance;

    public GameObject gameMenu;
    private GameObject gameMenuInstance;
    private bool gameMenuOpened;

    public GameObject player; //The player GameObject on the scene

    private Transform SpawnPosition; //The location that the player will spawn

    private string currentScene;

    private const string START_MENU = "StartMenu";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnNewScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentScene != START_MENU)
        {
            ToggleMenu();
        }
    }
	
    public static GameManager Get()
    {
        return instance;
    }

    public static AudioManager GetAudioManager()
    {
        return Get().GetAudio();
    }

    private AudioManager GetAudio()
    {
        return GetComponent<AudioManager>();
    }

    //Updates the spawnPosition
    public void UpdateSpawnPosition(Transform newPosition)
    {
        SpawnPosition = newPosition;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    //Moves the player to the SPawnPosition and Calls playerHealth Healing function
    public void GameOver()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        StartCoroutine(RestartGame(playerHealth));
    }

    //Restarts Players health and position with a .5 second delay
    IEnumerator RestartGame(PlayerHealth playerHealth)
    {
        yield return new WaitForSeconds(.1f);
        playerHealth.HealDamage(playerHealth.maxHealth);
        player.transform.position = SpawnPosition.position;

    }

    private void OnNewScene(Scene next, LoadSceneMode mode)
    {
        currentScene = next.name;
    }

    public void ToggleMenu()
    {
        if (gameMenuOpened) 
        {
            Time.timeScale = 0;
            gameMenuInstance = Instantiate(gameMenu);
        } 
        else 
        {
            Time.timeScale = 1;
            Destroy(gameMenuInstance);
        }
        gameMenuOpened = !gameMenuOpened;
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene(START_MENU);
        Time.timeScale = 1;
    }
}
