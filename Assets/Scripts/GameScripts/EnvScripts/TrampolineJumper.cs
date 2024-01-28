using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineJumper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
        }
    }
}
