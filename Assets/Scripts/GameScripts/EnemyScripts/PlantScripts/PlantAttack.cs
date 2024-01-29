using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    private float bulletSpeed = 200f;
    private float waitTime = 1f;
    private float attackDamage = 30f;
    private Animator animator;
    
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private GameObject player;
    private static readonly int AttackTrig = Animator.StringToHash("attack_trig");

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Initialize(float attackSpeed, float waitTime, float attackDamage, GameObject player)
    {
        this.bulletSpeed = attackSpeed;
        this.waitTime = waitTime;
        this.attackDamage = attackDamage;
        this.player = player;
    }
    private void FixedUpdate()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0 && player != null)
        {
            if(Math.Abs(player.transform.position.x - transform.position.x) > 10) return;
            animator.SetTrigger(AttackTrig);
            waitTime = 1f;
        }
    }
    
    public void Attack()
    {   
        // Instantiate a projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<PlantProjectileMovement>().Initialize(attackDamage);
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.localScale.x * bulletSpeed, 0));
    }
}
