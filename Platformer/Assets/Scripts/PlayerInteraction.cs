using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool isTouchingInteractable = false;
    private GameObject interactable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTouchingInteractable)
        {
            interactable.GetComponent<Interactable>().Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Interactable")
        {
            isTouchingInteractable = true;
            interactable = collider.gameObject;
        }
    }

    void OnTriggerExit2D()
    {
        isTouchingInteractable = false;
    }
}
