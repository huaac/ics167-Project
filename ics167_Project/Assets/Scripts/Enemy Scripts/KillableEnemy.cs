using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// sublass of enemies, enemies that has healthbar

public abstract class KillableEnemy : Enemy, IDamageable
{

    protected int max_health = 100; // can be overrided for variation
    public int CurrentHealth { get; set; }

    public HealthBar health_bar;

    // sets max health to current health
    void Start()
    {
        CurrentHealth = max_health;
        health_bar.SetMaxHealth(max_health);
    }

    // added by Aissa Akiyama
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // method for taking in damage
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        ChangeHealthBar();
    }

    // shows current health to show on the health bar
    void ChangeHealthBar()
    {
        health_bar.SetHealth(CurrentHealth);
    }

    public abstract void OnCollisionEnter2D(Collision2D col);
}
