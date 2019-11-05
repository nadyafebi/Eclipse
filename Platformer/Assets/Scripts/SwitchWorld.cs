using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
    public GameObject sunWorld;
    public GameObject moonWorld;
    public bool sunActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (sunActive)
        {
            ShowWorld(moonWorld, false);
            ShowWorld(sunWorld, true);
        }
        else
        {
            ShowWorld(sunWorld, false);
            ShowWorld(moonWorld, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (sunActive)
            {
                ShowWorld(moonWorld, true);
                ShowWorld(sunWorld, false);
            }
            else
            {
                ShowWorld(sunWorld, true);
                ShowWorld(moonWorld, false);
            }
            sunActive = !sunActive;
        }
    }

    void ShowWorld(GameObject world, bool show)
    {
        Vector3 currentPos = world.transform.position;
        if (show)
        {
            world.transform.position = new Vector3(currentPos.x, currentPos.y, 0);
        }
        else
        {
            world.transform.position = new Vector3(currentPos.x, currentPos.y, -50);
        }
    }
}
