using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement of the player by reading user input
/// and using CharacterController2D.
/// </summary>
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private bool m_movable = true;
    public bool movable
    {
        get { return m_movable; }
        set
        {
            m_movable = value;
            horizontalMove = 0;
            if (animator)
            {
                animator.SetFloat("Speed", 0);
            }
            jump = false;
        }
    }

    [SerializeField] private float runSpeed;

    
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private bool jump = false;
    private bool swimming = false;

    private CharacterController2D controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (m_movable)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            verticalMove = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, verticalMove, swimming);
        jump = false;
    }

    public void OnJumping()
    {
        animator.SetBool("Jump", true);
        animator.SetBool("Fall", false);
    }

    public void OnFalling()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", true);
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", false);
    }

    public void OnSwimStart()
    {
        swimming = true;
        animator.SetBool("Swim", true);
    }

    public void OnSwimEnd()
    {
        swimming = false;
        animator.SetBool("Swim", false);
    }
}
