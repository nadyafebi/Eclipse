﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckForAllAcorns : MonoBehaviour
{
    public GameObject parentAcorn;
    public GameObject player;
    public GameObject dialogueArea;
    public GameObject nextArea;
    public GameObject illTree;
    public GameObject goldenAcorn;
    public Text countText;
    private int initialChildCount;
    private int currentChildCount;
    public GameObject moveLocation;
    public Vector3 spawnLoc;
    private bool isSet = false;

    // Start is called before the first frame update
    void Start()
    {
        initialChildCount = parentAcorn.transform.childCount;
        currentChildCount = initialChildCount;
        spawnLoc = player.transform.position;
        updateTextForChildren();
        
    }

    // Update is called once per frame
    void Update()
    {
        int activeChildren = parentAcorn.transform.childCount;
        if (activeChildren != currentChildCount)
        {
            currentChildCount = activeChildren;
            updateTextForChildren();

        }
        if (activeChildren == 0)
        {

            illTree.SetActive(true);
	    nextArea.SetActive(true);
	    goldenAcorn.SetActive(true);
            dialogueArea.SetActive(true);
            if (!isSet)
            {
                player.transform.position = spawnLoc;
                isSet = true;

            }
            
        }
    }

    void updateTextForChildren()
    {
        int collected = initialChildCount - currentChildCount;
        if (collected < 10)
        {
            countText.text = "0" + collected.ToString() + "/" + initialChildCount.ToString();
        }
        else
        {
            countText.text = "" + collected.ToString() + "/" + initialChildCount.ToString();
        }
    }
}
