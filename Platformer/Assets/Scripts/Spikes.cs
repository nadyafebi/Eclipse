using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject player;

    //Gets call when a trigger collision happens on the game scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")//if Player hits the weakspot then
        {
            if (player.transform.position.y - player.transform.position.y >= 0)
            {
                //player.GetComponent<CharacterController2D>().Move(player.GetComponent<Rigidbody2D>().velocity.x, true);
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 1000f));
                // m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, m_JumpForceOnEnemies);
            }
        }
    }
}
