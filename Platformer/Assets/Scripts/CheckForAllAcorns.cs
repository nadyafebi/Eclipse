using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForAllAcorns : MonoBehaviour
{
    public GameObject parentAcorn;
    public GameObject Tree;
    //private int initialChildCount;

    // Start is called before the first frame update
    void Start()
    {
        //initialChildCount = parentAcorn.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        int activeChildren = parentAcorn.transform.childCount;
        if (activeChildren == 0)
        {
            Tree.SetActive(true);
        }
    }
}
