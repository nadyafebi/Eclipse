using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAndWall : MonoBehaviour
{


    //public GameObject button;
    public GameObject block;
    public GameObject wall;
    public GameObject noBZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().IsTouching(block.GetComponent<Collider2D>())){
            wall.SetActive(false);
            noBZone.SetActive(false);
        }
    }

}
