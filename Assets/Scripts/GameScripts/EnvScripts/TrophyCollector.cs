using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollector : MonoBehaviour
{
    private GameObject manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            manager.GetComponent<GameManager>().GameOver(true);
        }
    }
}
