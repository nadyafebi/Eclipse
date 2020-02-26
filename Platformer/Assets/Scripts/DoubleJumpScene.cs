using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpScene : MonoBehaviour
{
    public GameObject player;

    private CharacterController2D controller;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController2D>();
	playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
	if (GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<Collider2D>()))
	{
	    // ADD DIALOGUE SAYING PLAYER CAN NOW DOUBLE JUMP
	    controller.m_AirJumps = 1;
	    Destroy(gameObject); // make luna pause, show text, change to double jump
	}
        
    }
}
