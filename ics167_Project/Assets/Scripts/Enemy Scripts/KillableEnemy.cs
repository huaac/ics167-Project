using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// sublass of enemies, enemies that has healthbar

// edited by Aissa Akiyama

public abstract class KillableEnemy : Enemy, IDamageable
{

    protected int max_health = 100; // can be overrided for variation
    public int CurrentHealth { get; set; }

    public HealthBar health_bar;

    // sets max health to current health
    virtual protected void Awake()
    {
        CurrentHealth = max_health;
        health_bar.SetMaxHealth(max_health);
    }

    // added by Aissa Akiyama
    // method for taking in damage
    virtual public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        ChangeHealthBar();

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // shows current health to show on the health bar
    virtual protected void ChangeHealthBar()
    {
        health_bar.SetHealth(CurrentHealth);
    }

    //public abstract void OnCollisionEnter2D(Collision2D col);

    // A killable enemy will take damage when the Helper attacks it, just like
    // when a player with the protein powerup attacks it.
    protected override void OnHelperAttack(int damage)
    {
        TakeDamage(damage);
    }
}
