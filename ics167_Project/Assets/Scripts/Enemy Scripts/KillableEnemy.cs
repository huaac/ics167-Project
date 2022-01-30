using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEnemy : MonoBehaviour
{

    protected int max_health = 100;
    protected int current_health;

    public HealthBar health_bar;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        health_bar.SetMaxHealth(max_health);
    }

    void TakeDamage(int damage)
    {
        current_health -= damage;
        ChangeHealthBar();
    }

    void ChangeHealthBar()
    {
        health_bar.SetHealth(current_health);
    }
}
