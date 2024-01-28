using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Collectable", menuName = "ScriptableObjects/Collectable", order = 1)]
public class Collectable : ScriptableObject
{
    [SerializeField] private Vector3 position;

    public Vector3 Position => position;


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
            Destroy(this);

        }
    }
}
