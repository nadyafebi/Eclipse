using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckForAllAcorns : MonoBehaviour
{
    public GameObject parentAcorn;
    public GameObject player;
    public GameObject dialogueArea;
    public GameObject nextArea;
    public Text countText;
    private int initialChildCount;
    private int currentChildCount;
    public GameObject moveLocation;
    private bool isSet = false;

    // Start is called before the first frame update
    void Start()
    {
        initialChildCount = parentAcorn.transform.childCount;
        currentChildCount = initialChildCount;
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

            //illTree.SetActive(false);
            dialogueArea.SetActive(true);
            player.transform.position = moveLocation.transform.position;
            nextArea.SetActive(true);
        }
    }

    void updateTextForChildren()
    {
        int collected = initialChildCount - currentChildCount;
        if (collected < 10)
        {
            countText.text = "Acorns Collected: 0" + collected.ToString() + "/" + initialChildCount.ToString();
        }
        else
        {
            countText.text = "Acorns Collected: " + collected.ToString() + "/" + initialChildCount.ToString();
        }
    }
}
