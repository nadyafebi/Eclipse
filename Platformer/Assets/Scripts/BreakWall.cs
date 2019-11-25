using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GetComponent<Rigidbody2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            gameObject.SetActive(false);

        }

    }
}
