using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public struct StageMusic
    {
        public string name;
        public AudioClip clip;
    }

    public StageMusic[] stageMusics;

    private AudioSource player;

    private Dictionary<string, AudioClip> musics = new Dictionary<string, AudioClip>();

    private static bool created = false;

    void Awake()
    {
        // This makes the game object goes over to the next scene.
        DontDestroyOnLoad(this);

        if (!created)
        {
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GetComponent<AudioSource>();

        // Convert stage musics to a dictionary.
        foreach (var music in stageMusics)
        {
            musics[music.name] = music.clip;
        }

        // Add listener that triggers when scene changes.
        SceneManager.activeSceneChanged += OnNewScene;

        // Play the first song.
        player.clip = musics[SceneManager.GetActiveScene().name];
        player.Play();
    }

    void OnNewScene(Scene current, Scene next)
    {
        if (musics.ContainsKey(next.name))
        {
            player.clip = musics[next.name];
            player.volume = 1.0f;
            player.pitch = 1.0f;
            player.Play();
        }
    }

    public IEnumerator FadeAudio(float duration)
    {
        float startVolume = player.volume;
        while (player.volume > 0)
        {
            player.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
    }

    public void SetPitch(float pitch)
    {
        player.pitch = pitch;
    }
}
