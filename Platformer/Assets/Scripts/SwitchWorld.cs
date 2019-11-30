﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchWorld : MonoBehaviour
{
    [System.Serializable]
    public enum WorldMode {Sun, Moon};

    public WorldMode active;

    public GameObject sunWorld;
    public GameObject moonWorld;
    public GameObject sunPlayer;
    public GameObject moonPlayer;
    public GameObject cameraControl;

    private CinemachineVirtualCamera m_camera;

    private AudioManager audioManager;

    void Start()
    {
        m_camera = cameraControl.GetComponent<CinemachineVirtualCamera>();

        GameObject audioObject = GameObject.Find("AudioManager");
        if (audioObject)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }

        Set(active);
    }

    void Update()
    {
        // Switch world whenever a key is pressed.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Switch();
        }
    }

    public void Switch()
    {
        if (active == WorldMode.Moon)
        {
            Set(WorldMode.Sun);
        }
        else
        {
            Set(WorldMode.Moon);
        }
    }

    public void Set(WorldMode mode)
    {
        active = mode;
        if (active == WorldMode.Moon)
        {
            sunWorld.SetActive(false);
            moonWorld.SetActive(true);
            m_camera.Follow = moonPlayer.transform;

            if (audioManager)
            {
                audioManager.SetPitch(0.75f);
            }
        }
        else
        {
            moonWorld.SetActive(false);
            sunWorld.SetActive(true);
            m_camera.Follow = sunPlayer.transform;

            if (audioManager)
            {
                audioManager.SetPitch(1.25f);
            }
        }
    }
}
