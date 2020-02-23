using System.Collections;
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
    private HealthBar healthBar;

    void Start()
    {
        audioManager = GameManager.GetAudioManager();
        m_camera = cameraControl.GetComponent<CinemachineVirtualCamera>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();

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
            healthBar.SwitchColor(HealthBar.OrbColor.Blue);

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
            healthBar.SwitchColor(HealthBar.OrbColor.Red);

            if (audioManager)
            {
                audioManager.SetPitch(1.25f);
            }
        }
    }
}
