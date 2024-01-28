using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float playerHealth = 100f;
    
    private Animator animator;
    private bool isDead = false;
    private Rigidbody2D rb;

    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y < -5)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        if(isDead) return; 
        animator.SetTrigger("death_trig");
        
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        isDead = true;
        manager.GetComponent<GameManager>().GameOver();

        //Invoke("DestroyPlayerObject", 0.2f);
    }
    
    public void DestroyPlayerObject()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            KillPlayer();
        }
    }
    
    public bool IsDead()
    {
        return isDead;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(other.gameObject.GetComponent<EnemyStatus>().GetDamage());
        }
    }
}
