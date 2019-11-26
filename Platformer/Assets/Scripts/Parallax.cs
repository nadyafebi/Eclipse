using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    
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
        float dist = cam.transform.position.x * effect;

        transform.position = new Vector3(startX + dist, transform.position.y, transform.position.z);
    }
}
