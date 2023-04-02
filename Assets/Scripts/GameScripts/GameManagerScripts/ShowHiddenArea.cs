using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenArea : MonoBehaviour
{
    private GameObject player;
    public GameObject foreground;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            float y = player.transform.position.y;
            float x = player.transform.position.x;
            if (y < -3.5f && y > -4.0f && x > -0.6f && x < -0.4f)
            {
                foreground.gameObject.SetActive(false);
            }
        }
        
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
    }
}
