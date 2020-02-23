using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Needed to create Image instances

/// <summary>
/// Handles the life of the player by:
/// - Specifing health amount and keeping track of current health.
/// - Getting access to the UI HealthBar element and updating it based on health.
/// - Contains methods to damage the player.
/// - Handles when the player gets hurt.
/// </summary>
public class PlayerHealth : MonoBehaviour {
    public bool immune;
    public int maxHealth;
    public int currentHealth;

    private SpriteRenderer playerSprite;
    private HealthBar healthBar;

    private GameManager gameManager;
    private CharacterController2D characterController2D;

    void Start()
    {
        gameManager = GameManager.Get();
        gameManager.SetPlayer(gameObject);
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        playerSprite = GetComponent<SpriteRenderer>();
        characterController2D = GetComponent<CharacterController2D>();

        // At start of scene, player gets max health.
        currentHealth = maxHealth;
        healthBar.Set(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
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
	
    /// <summary>
    /// Deals damage to the player based on the specified amount and updates the UI.
    /// </summary>
    /// <param name="damage">Damage to be taken by the player.</param>
	public void TakeDamage(int damage)
    {
        if (!immune)
        {
            currentHealth -= damage;
            healthBar.Set(currentHealth);

            if(currentHealth <= 0)
            {
                gameManager.GameOver();
            }
        }
    }

    /// <summary>
    /// Heals the player based on the specified amount and updates the UI.
    /// </summary>
    /// <param name="healAmount">Amount of health to be added to the player.</param>
    public void HealDamage(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.Set(currentHealth);
    }

    /// <summary>
    /// Calls `TakeDamage` and makes player immune for a short interval before they can get hit again.
    /// </summary>
    IEnumerator DamageState()
    {
        TakeDamage(1);
        immune = true;
        yield return new WaitForSeconds(1f); //Time before they can get hit again
        immune = false;

    }

    /// <summary>
    /// Makes the player's sprite blink.
    /// </summary>
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
