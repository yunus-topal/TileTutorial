using System;
using System.Collections;
using System.Collections.Generic;
using GameScripts.PlayerScripts;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerStatus>().KillPlayer();
        }
    }
}
