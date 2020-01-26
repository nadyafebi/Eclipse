﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the overall game logic.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Refers to the instace of managers. There can only be one!
    /// </summary>
    private static GameManager instance;
    private static AudioManager audioManager;

    public GameObject player; //The player GameObject on the scene
    private Transform SpawnPosition; //The location that the player will spawn

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        audioManager = GetComponent<AudioManager>();
    }
	
    public static GameManager Get() {
        return instance;
    }

    public static AudioManager GetAudioManager() {
        return audioManager;
    }

    //Updates the spawnPosition
    public void UpdateSpawnPosition(Transform newPosition)
    {
        SpawnPosition = newPosition;
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
}
