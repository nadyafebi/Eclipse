using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Needed to create Image instances

public class PlayerHealth : MonoBehaviour {

    /// <summary>
    /// PlayerHealth handles the life of the Player by:
    /// -Specifing health amount and keeping track of current Health
    /// -Getting access to the UI healthBar element and updating it base on health
    /// -Contains methods that damage the player
    /// -Handles when the playaer gets hurt
    /// </summary>

    public float maxHealth;
    public float currentHealth;
    public bool immune;
    public GameObject healthBarObject; //UI Bar
    private GameManager gameManager;
    private SpriteRenderer playerSprite;
    private CharacterController2D characterController2D;
    private HealthBar healthBar;

    void Start () {
        gameManager = GameManager.Get();
        gameManager.SetPlayer(gameObject);
        healthBar = healthBarObject.GetComponent<HealthBar>();
        playerSprite = GetComponent<SpriteRenderer>();
        characterController2D = GetComponent<CharacterController2D>();

        currentHealth = maxHealth; //At start of scene, player gets max health
        healthBar.Set((int)currentHealth);
    }
	
    //Deals damage to player base on specified amount and updates UI and stats
	public void TakeDamage(float damage)
    {
        if (!immune)
        {

            currentHealth -= damage;
            // float health = currentHealth / maxHealth;
            healthBar.Set((int)currentHealth);
            if(currentHealth <= 0)      //If health goes to 0 or below, call GameOver in GameManager
            {
                gameManager.GameOver();
            }
        }

    }

    //Heals Damage to the player base on specified amount and updates the UI
    public void HealDamage(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) //If health goes above max health then cap it at max health
            currentHealth = maxHealth;

        // float health = currentHealth / maxHealth;
        healthBar.Set((int)currentHealth);
    }

    //ONTriggerEnter2D is called when another trigger collider hits any of the player's colliders
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurtBox" && this.gameObject.transform.position.y - collision.gameObject.transform.position.y >= 0)
        {
            characterController2D.Jump(25f);

        }
        if (collision.gameObject.tag == "HitBox")
        {
            if (!immune)
            {
                StartCoroutine(BlinkSprite());
                StartCoroutine(DamageState());
            }
        }
    }

    //Calls Take Damage, and makes Player Immune for a short interval before they can get hit again
    IEnumerator DamageState()
    {
        TakeDamage(1);
        immune = true;
        yield return new WaitForSeconds(1f); //Time before they can get hit again
        immune = false;

    }

    //Makes the player's sprite blink
    IEnumerator BlinkSprite()
    {
        for (int i = 0; i < 8; ++i)
        {
            yield return new WaitForSeconds(.05f);

            if (playerSprite.enabled == true)
                playerSprite.enabled = false;

            else
                playerSprite.enabled = true;
        }
    }
}
