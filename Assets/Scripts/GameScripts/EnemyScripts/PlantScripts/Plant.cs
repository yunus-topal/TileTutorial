using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Plant", menuName = "ScriptableObjects/Plant", order = 1)]
public class Plant : ScriptableObject
{
    [SerializeField] private Vector3 position;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float waitTime;
    [SerializeField] private float attackDamage;

    public Vector3 Position => position;

    public float BulletSpeed => bulletSpeed;

    public float WaitTime => waitTime;

    public float AttackDamage => attackDamage;
}
