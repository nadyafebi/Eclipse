using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [System.Serializable]
    public enum OrbColor {Blue, Red};

    /// <summary>
    /// A GameObject containing the image of the orb.
    /// </summary>
    [Tooltip("A GameObject containing an image of the orb.")]
    public GameObject orb;

    public RuntimeAnimatorController blueOrbController;
    public RuntimeAnimatorController redOrbController;

    public OrbColor currentColor = OrbColor.Blue;

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

    void Start()
    {
        GameManager.Get().healthBar = this;
        SwitchColor(currentColor);
    }

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

        // Set the color of the orb.
        SetColor(newOrb, currentColor);
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
            StartCoroutine(Remove(lastOrb));
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

    public void SetColor(GameObject orb, OrbColor color)
    {
        Animator animator = orb.GetComponent<Animator>();
        if (color == OrbColor.Blue)
        {
            animator.runtimeAnimatorController = blueOrbController;
        }
        else if (color == OrbColor.Red)
        {
            animator.runtimeAnimatorController = redOrbController;
        }
    }

    public void SwitchColor(OrbColor color)
    {
        if (color != currentColor)
        {
            currentColor = color;
            foreach (var orb in orbs)
            {
                SetColor(orb, color);
            }
        }
    }

    private IEnumerator Remove(GameObject orb)
    {
        orb.GetComponent<Animator>().SetBool("Vanish", true);
        yield return new WaitForSeconds(1f);
        Destroy(orb);
    }
}
