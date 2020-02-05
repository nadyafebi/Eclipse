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

    private string lastScene;

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
        lastScene = SceneManager.GetActiveScene().name;

        // Play the first song.
        string sceneName = SceneManager.GetActiveScene().name;
        PlayBGM(sceneName);
    }

    void PlayBGM(string sceneName)
    {
        if (musics.ContainsKey(sceneName))
        {
            player.clip = musics[sceneName];
            player.volume = 1.0f;
            player.pitch = 1.0f;
            player.Play();
        }
        else
        {
            if (Char.IsNumber(sceneName[0]))
            {
                sceneName = sceneName[0].ToString();
                PlayBGM(sceneName);
            }
        }
    }

    void OnNewScene(Scene current, Scene next)
    {
        if (next.name[0] != lastScene[0])
        {
            PlayBGM(next.name);
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
