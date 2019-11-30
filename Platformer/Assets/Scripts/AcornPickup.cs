using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornPickup : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
