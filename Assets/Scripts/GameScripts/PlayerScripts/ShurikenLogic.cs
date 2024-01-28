using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenLogic : MonoBehaviour
{
    
    [SerializeField] private float speed = 45f;
    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate the shuriken
        transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
    
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        // todo: add logic for killing enemies
        if  (other.gameObject.CompareTag("Player"))return;
        if (other.gameObject.CompareTag("Enemy")) other.gameObject.GetComponent<EnemyStatus>().TakeDamage(4f);
        Destroy(gameObject);
    }
}
