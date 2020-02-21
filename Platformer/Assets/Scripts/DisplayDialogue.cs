using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDialogue : MonoBehaviour
{

    public GameObject sunPlayer;
    public GameObject moonPlayer;
    public GameObject dialogue;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(moonPlayer.GetComponent<Collider2D>())
            || GetComponent<BoxCollider2D>().IsTouching(sunPlayer.GetComponent<Collider2D>()))
        {
            dialogue.SetActive(true);
        }
    }
}
