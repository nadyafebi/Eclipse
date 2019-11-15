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
        if ((Input.GetButtonDown("Vertical") && moonWorld.activeSelf))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400f));

        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        //if (body == null || body.isKinematic)
          //  return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f || hit.Equals(moonPlayer)) 
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down (that we do in update)
        if (sunWorld.activeSelf && hit.Equals(sunPlayer)) { 
            controller.Move(hit.moveDirection.x* 2 * Time.fixedDeltaTime, jump);
        }
    }
}
