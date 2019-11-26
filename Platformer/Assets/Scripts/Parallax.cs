using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject camera;
    
    [Range(0f, 1f)]
    public float effect = 0.5f;

    private float startX;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = camera.transform.position.x * (1 - effect);
        float dist = camera.transform.position.x * effect;

        transform.position = new Vector3(startX + dist, transform.position.y, transform.position.z);

        // if (temp > startX)
        // {
        //     startX += length;
        // }
    }
}
