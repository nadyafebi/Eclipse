using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Slider volumeSlider;

    private GameManager gameManager;
    private AudioManager audioManager;

    void Start()
    {
        gameManager = GameManager.Get();
        audioManager = GameManager.GetAudioManager();

        volumeSlider.value = audioManager.GetVolume();
    }

    public void GoToStartMenu()
    {
        gameManager.GoToStartMenu();
    }

    public void VolumeSliderChanged()
    {
        float volume = volumeSlider.value;
        audioManager.SetVolume(volume);
    }
}
