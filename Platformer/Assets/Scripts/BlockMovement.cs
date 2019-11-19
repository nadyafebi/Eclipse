using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public GameObject sunWorld;
    public GameObject moonWorld;
    public GameObject sunPlayer;
    public GameObject moonPlayer;

    bool jump = false;
    public CharacterController2D controller;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().IsTouching(moonPlayer.GetComponent<Collider2D>()))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
        else
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if ((Input.GetButtonDown("Vertical") && moonWorld.activeSelf))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400f));

        }
        if (GetComponent<Rigidbody2D>().IsTouching(sunPlayer.GetComponent<Collider2D>()))
        {
            controller.Move(sunPlayer.GetComponent<Rigidbody2D>().position.x * 2 * Time.fixedDeltaTime, jump);
            
        }
    }

    
}
