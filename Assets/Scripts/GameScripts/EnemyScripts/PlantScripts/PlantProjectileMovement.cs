using System.Collections;
using System.Collections.Generic;
using GameScripts.PlayerScripts;
using UnityEngine;

public class PlantProjectileMovement : MonoBehaviour
{
    private float rotateSpeed = 100f;
    private float attackDamage;
    public void Initialize(float attackDamage)
    {
        this.attackDamage = attackDamage;
    }
    
    void FixedUpdate()
    {
        // Rotate the projectile
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }
    
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.gameObject.GetComponent<PlayerStatus>().TakeDamage(attackDamage);
        Destroy(gameObject);
    }
}
