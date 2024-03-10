using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ghost", menuName = "ScriptableObjects/Ghost", order = 1)]
public class Ghost : ScriptableObject
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float disappearDelay = 1f;
    
    public Vector3 StartPosition => startPosition;
    public float Speed => speed;
    public float DisappearDelay => disappearDelay;
}
