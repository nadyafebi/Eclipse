using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDialogue : MonoBehaviour
{

    public GameObject sunPlayer;
    public GameObject moonPlayer;
    public GameObject dialogueObject;
    // private Dialogue dialogue;
    private bool triggered = false;
    private void Start()
    {
        // dialogue = dialogueObject.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(moonPlayer.GetComponent<Collider2D>())
            || GetComponent<BoxCollider2D>().IsTouching(sunPlayer.GetComponent<Collider2D>()))
        {
            if (!triggered)
            {
                sunPlayer.GetComponent<PlayerMovement>().movable = false;
		moonPlayer.GetComponent<PlayerMovement>().movable = false;
                dialogueObject.SetActive(true);
                triggered = true;
            }
        }
    }

    public void makeMovable()
    {
        sunPlayer.GetComponent<PlayerMovement>().movable = true;
        moonPlayer.GetComponent<PlayerMovement>().movable = true;
    }
}
