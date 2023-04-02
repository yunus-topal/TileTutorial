using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
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
        manager.GetComponent<GameManager>().GameOver();
        Destroy(gameObject);
    }
}
