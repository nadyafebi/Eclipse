using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FancyTreeParticles();
        }
    }

    public void FancyTreeParticles()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }
}
