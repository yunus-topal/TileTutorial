using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    private GameObject manager;
    private bool isColliding;
    private void Start()
    {
        isColliding = false;
        manager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            if(isColliding) return;
            isColliding = true;
            manager.GetComponent<GameManager>().IncrementFruit();
            Destroy(gameObject);

        }
    }
}
