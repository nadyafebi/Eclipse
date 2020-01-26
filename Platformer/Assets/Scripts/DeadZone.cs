using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to define areas in which the player instantly dies and triggers Game Over sequence
/// </summary>
public class DeadZone : MonoBehaviour {


    private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameManager.Get();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Triggers GameOver if player hits a DeadZone area on the game scene
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameManager.GameOver();
        }
       
    }
}
