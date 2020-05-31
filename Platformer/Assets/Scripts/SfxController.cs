using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volumeScale = 0.5f;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameManager.GetAudioManager();
        audioManager.PlaySFX(clip, volumeScale);
    }
}
