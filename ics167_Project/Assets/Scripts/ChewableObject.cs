using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewableObject : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; set; }

    void Start()
    {
        CurrentHealth = 1;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = 0;
        Destroy(gameObject);
    }
}