using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    private GameObject manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            manager.GetComponent<GameManager>().IncrementFruit();
            Destroy(gameObject);
        }
    }
}
