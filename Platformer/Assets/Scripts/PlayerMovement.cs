﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement of the player by reading user input
/// and using CharacterController2D.
/// </summary>
public class PlayerMovement : MonoBehaviour {
    public bool movable = true;

    [SerializeField] private float runSpeed;
    
    private float horizontalMove = 0f;
    private bool jump = false;

    private CharacterController2D controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (movable)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
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
        animator.SetBool("Swim", true);
    }

    public void OnSwimEnd()
    {
        animator.SetBool("Swim", false);
    }
}
