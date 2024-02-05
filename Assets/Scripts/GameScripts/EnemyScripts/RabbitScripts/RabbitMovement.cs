using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = -5f;
    private bool goingLeft = true;
    
    private float jumpForce = 200f;
    private bool isGrounded = false;
    private float jumpCooldown = 1.5f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2( goingLeft ? speed : speed * -1, rb.velocity.y);
        animator.SetFloat("horizontal_speed", 1f);
    }

    private void FixedUpdate()
    {
        jumpCooldown -= Time.deltaTime;
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
        animator.SetBool("grounded", isGrounded);
        // check if there is a wall in front of the rabbit
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(rb.velocity.x,0), 0.2f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            goingLeft = !goingLeft;
            // if there is a wall, turn around
            var localScale = transform.localScale;
            localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            transform.localScale = localScale;
        }
        rb.velocity = new Vector2( goingLeft ? speed : speed * -1, rb.velocity.y);
    
        if (jumpCooldown <= 0 && isGrounded)
        {
            animator.SetTrigger("jump_trig");
            rb.AddForce(new Vector2(0, jumpForce));
            jumpCooldown = 1.5f;
        }
        
        animator.SetFloat("vert_speed", rb.velocity.y);
    }

    public void SetRabbitSpeed(float f)
    {
        speed = f;
    }
}
