using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float speed = 20f;
    private float direction = 0f;

    private bool isJumping = false;

    private bool isCrouching = false;

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Math.Abs(direction * speed));
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetTrigger("jump_trig");
        }
        /*
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }*/ // This is commented out because crouch is disabled for now.
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(direction * speed * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }
}
