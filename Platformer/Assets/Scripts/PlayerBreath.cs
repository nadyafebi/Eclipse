using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBreath : MonoBehaviour
{
    [SerializeField] private float maxOxygen = 10;
    [SerializeField] private float currentOxygen;

    private bool swimming;
    private IEnumerator breatheCoroutine;

    private GameObject breathBarObject;
    private Image breathBar;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Get();
        breathBarObject = GameObject.Find("GameUI").transform.Find("BreathBar").gameObject;
        breathBar = breathBarObject.transform.Find("Bar").GetComponent<Image>();
        currentOxygen = maxOxygen;
    }

    public void SwimStart()
    {
        swimming = true;
        breathBarObject.SetActive(true);
        if (breatheCoroutine == null)
        {
            StartCoroutine(Breathe());
        }
    }

    public void SwimEnd()
    {
        swimming = false;
    }

    IEnumerator Breathe()
    {
        while (true)
        {
            if (swimming)
            {
                if (currentOxygen > 0)
                {
                    currentOxygen--;
                }
                else
                {
                    gameManager.GameOver();
                    breathBarObject.SetActive(false);
                    breatheCoroutine = null;
                    currentOxygen = maxOxygen;
                    yield break;
                }

                breathBar.fillAmount = currentOxygen / maxOxygen;
                yield return new WaitForSeconds(1);
            }
            else
            {
                currentOxygen++;
                breathBar.fillAmount = currentOxygen / maxOxygen;

                if (currentOxygen >= maxOxygen)
                {
                    breathBarObject.SetActive(false);
                    breatheCoroutine = null;
                    yield break;
                }

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
