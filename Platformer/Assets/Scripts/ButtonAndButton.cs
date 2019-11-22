using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAndButton : MonoBehaviour
{
    //public GameObject button;
    public GameObject block;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().IsTouching(block.GetComponent<Collider2D>()))
        {
            button2.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
