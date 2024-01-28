using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 10f;
    [SerializeField] private float enemyDamage = 40f;
    
    private Animator animator;
    private bool invulnerable = false;

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
