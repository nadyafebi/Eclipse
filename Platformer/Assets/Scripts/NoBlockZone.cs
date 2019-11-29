using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBlockZone : MonoBehaviour
{

    public GameObject block;
    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = block.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(block.GetComponent<Collider2D>()))
        {
            block.transform.position = startingPos;
            block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
