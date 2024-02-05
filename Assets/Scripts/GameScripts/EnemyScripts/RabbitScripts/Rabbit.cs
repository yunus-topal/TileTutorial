using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Rabbit", menuName = "ScriptableObjects/Rabbit", order = 1)]
public class Rabbit: ScriptableObject
{
    [SerializeField] private Vector3 position;
    [SerializeField] private float speed;
    
    public Vector3 Position => position;
    public float Speed => speed;
}
