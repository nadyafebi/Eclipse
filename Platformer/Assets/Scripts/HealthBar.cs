using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /// <summary>
    /// A GameObject containing the image of the orb.
    /// </summary>
    [Tooltip("A GameObject containing an image of the orb.")]
    public GameObject orb;

    /// <summary>
    /// Size of individual orb.
    /// </summary>
    public float orbSize;

    /// <summary>
    /// Gap between each orbs.
    /// </summary>
    [Tooltip("Gap between each orbs.")]
    public float orbGap;

    private List<GameObject> orbs = new List<GameObject>();


    /// <summary>
    /// Adds an orb to the health bar.
    /// </summary>
    public void Add()
    {
        // Create a new orb and set it to be the bar's child.
        GameObject newOrb = Instantiate(orb);
        orbs.Add(newOrb);
        newOrb.transform.SetParent(transform);

        // Set the position of the orb depending on how many orbs we have.
        float x = orbSize * orbs.Count + orbGap * (orbs.Count - 1);
        ((RectTransform)newOrb.transform).anchoredPosition = new Vector2(x, 0);
    }

    /// <summary>
    /// Removes an orb from the health bar.
    /// </summary>
    public void Remove()
    {
        if (orbs.Count > 0)
        {
            int last = orbs.Count - 1;
            GameObject lastOrb = orbs[last];
            orbs.RemoveAt(last);
            lastOrb.GetComponent<Animator>().SetBool("Vanish", true);
            Destroy(lastOrb, 1.5f);
        }
    }

    /// <summary>
    /// Sets the amount of orbs of the health bar.
    /// </summary>
    public void Set(int health)
    {
        int diff = Mathf.Abs(health - orbs.Count);
        if (orbs.Count < health)
        {
            for (int i = 0; i < diff; i++)
            {
                Add();
            }
        }
        else if (orbs.Count > health)
        {
            for (int i = 0; i < diff; i++)
            {
                Remove();
            }
        }
    }
}
