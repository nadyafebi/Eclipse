using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornPickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject player;

    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameManager.GetAudioManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            audioManager.PlaySFX(pickupSound);
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
