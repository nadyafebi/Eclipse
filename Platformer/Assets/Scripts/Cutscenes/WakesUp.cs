using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Cutscenes/Wakes Up")]
public class WakesUp : MonoBehaviour
{
    [FormerlySerializedAs("luna")]
    public GameObject player;
    public AnimationClip wakeUpAnimation;

    private Animator animator;
    private PlayerMovement movement;

    void Start()
    {
        animator = player.GetComponent<Animator>();
        movement = player.GetComponent<PlayerMovement>();
        
        StartCoroutine(WakeUp());
    }

    private IEnumerator WakeUp()
    {
        movement.movable = false;
        animator.SetBool("Sleep", true);
        yield return new WaitForSeconds(wakeUpAnimation.length);
        animator.SetBool("Sleep", false);
        movement.movable = true;
    }
}
