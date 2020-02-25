using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Cutscenes/Luna Wakes Up")]
public class LunaWakesUp : MonoBehaviour
{
    public GameObject luna;
    public AnimationClip wakeUpAnimation;

    private Animator lunaAnimator;
    private PlayerMovement lunaMovement;

    void Start()
    {
        lunaAnimator = luna.GetComponent<Animator>();
        lunaMovement = luna.GetComponent<PlayerMovement>();
        
        StartCoroutine(WakeUp());
    }

    private IEnumerator WakeUp()
    {
        lunaMovement.movable = false;
        lunaAnimator.SetBool("Sleep", true);
        yield return new WaitForSeconds(wakeUpAnimation.length);
        lunaAnimator.SetBool("Sleep", false);
        lunaMovement.movable = true;
    }
}
