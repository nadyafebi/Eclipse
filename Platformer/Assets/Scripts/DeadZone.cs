using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Used to define areas in which the player instantly dies and triggers Game Over sequence
/// </summary>
public class DeadZone : MonoBehaviour
{
    public enum WorldMode {Sun, Moon};
    public WorldMode active;

    public GameObject moonPlayer;
    public AnimationClip moonDeath;
    public AnimationClip moonRevive;
    public GameObject sunPlayer; 
    public AnimationClip sunDeath;
    public AnimationClip sunRevive;
    //public GameObject testing;

    private Animator animator;
    private PlayerMovement movement;


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
	    if (active == WorldMode.Moon)
	    {
	        animator = moonPlayer.GetComponent<Animator>();
	        movement = moonPlayer.GetComponent<PlayerMovement>();
	        StartCoroutine(moonDeathAnimation());
	    }

	    if (active == WorldMode.Sun)
	    {
		animator = sunPlayer.GetComponent<Animator>();
	        movement = sunPlayer.GetComponent<PlayerMovement>();
	        StartCoroutine(sunDeathAnimation());
	    }
        }
	

    }

    private IEnumerator moonDeathAnimation()
    {
	movement.movable = false;
	animator.SetBool("Die", true);
	yield return new WaitForSeconds(moonDeath.length);
	animator.SetBool("Die", false);
	gameManager.GameOver();
	animator.SetBool("Revive", true);
	yield return new WaitForSeconds(moonRevive.length);
	animator.SetBool("Revive", false);
	movement.movable = true;
    }

    private IEnumerator sunDeathAnimation()
    {
	movement.movable = false;
	animator.SetBool("Die", true);
	yield return new WaitForSeconds(sunDeath.length);
	animator.SetBool("Die", false);
	gameManager.GameOver();
	animator.SetBool("Revive", true);
	yield return new WaitForSeconds(sunRevive.length);
	animator.SetBool("Revive", false);
	movement.movable = true;
    }


}