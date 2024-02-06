using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] protected float enemyHealth = 10f;
    [SerializeField] private float enemyDamage = 40f;
    
    private Animator animator;
    private bool invulnerable = false;


    private void FixedUpdate()
    {
        if (transform.position.y < -5f) Destroy(gameObject);
    }
    

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable) return;
        animator.SetTrigger("hit_trig");
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        invulnerable = true;
        
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        // remove force from the enemy
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0;
    }
    
    public float GetDamage()
    {
        return enemyDamage;
    }
    
    public void SetVulnerable()
    {
        invulnerable = false;
    }
    
}
