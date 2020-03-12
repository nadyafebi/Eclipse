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

    private string currentScene;

    void Start()
    {
        player = GetComponent<AudioSource>();

        // Convert stage musics to a dictionary.
        foreach (var music in stageMusics)
        {
            musics[music.name] = music.clip;
        }

        // Add listener that triggers when scene changes.
        SceneManager.sceneLoaded += OnNewScene;
        currentScene = SceneManager.GetActiveScene().name;

        // Play the first song.
        PlayBGM(currentScene);
    }

    public void PlaySFX(AudioClip clip)
    {
        player.PlayOneShot(clip);
    }

    void PlayBGM(string sceneName)
    {
        if (musics.ContainsKey(sceneName))
        {
            player.clip = musics[sceneName];
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

    void OnNewScene(Scene next, LoadSceneMode mode)
    {
        if (next.name[0] != currentScene[0])
        {
            PlayBGM(next.name);
        }
        currentScene = next.name;
    }

    public IEnumerator FadeAudio(float duration)
    {
        float startVolume = player.volume;
        while (player.volume > 0)
        {
            player.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
        player.volume = startVolume;
    }

    public float GetVolume()
    {
        return player.volume;
    }

    public void SetVolume(float volume)
    {
        player.volume = volume;
    }

    public void SetPitch(float pitch)
    {
        player.pitch = pitch;
    }
}
