using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// sublass of enemies, enemies that has healthbar

public abstract class KillableEnemy : Enemy
{

    protected int max_health = 100; // can be overrided for variation
    protected int current_health;

    public HealthBar health_bar;

    // sets max health to current health
    void Start()
    {
        current_health = max_health;
        health_bar.SetMaxHealth(max_health);
    }

    // method for taking in damage
    protected void TakeDamage(int damage)
    {
        current_health -= damage;
        ChangeHealthBar();
    }

    // shows current health to show on the health bar
    void ChangeHealthBar()
    {
        health_bar.SetHealth(current_health);
    }

    public abstract void OnCollisionEnter2D(Collision2D col);
}
