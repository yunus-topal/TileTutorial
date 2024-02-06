using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pig", menuName = "ScriptableObjects/Pig", order = 1)]
public class Pig : ScriptableObject
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float waitTime = 1f;

    public Vector3 StartPosition => startPosition;

    public Vector3 TargetPosition => targetPosition;

    public float Speed => speed;

    public float WaitTime => waitTime;
}
