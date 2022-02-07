using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama
// Defines an abstract base class for power-ups. When a power-up is collected, it starts a timer that counts
// for a designer-specified amount of time, and the power-up expires when it reaches 0.
// Power-ups can be enabled/disabled on collection and expire by overriding the PowerUpApply() and
// PowerUpExpired() methods.

public abstract class PowerUp : MonoBehaviour
{
    protected PlayerState player;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] private GameEvent OnPowerUpCollected;
    [SerializeField] private GameEvent OnPowerUpExpired;
    [SerializeField] private float timer = 5f;

    private bool isInUse;


    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpCollected(other.gameObject);
    }

    protected virtual void PowerUpCollected(GameObject gameObjectCollectingPowerUp)
    {
        player = gameObjectCollectingPowerUp.GetComponent<PlayerState>();

        // check if colliding object was player
        if (!player)
        {
            return;
        }
        // check if player isn't using a powerup already
        if (player.IsUsingPowerUp)
        {
            return;
        }
        // check if we haven't been collected before
        if (isInUse)
        {
            return;
        }
        isInUse = true;

        OnPowerUpCollected.Raise(); // raise game event associated with collection of this power-up
        PowerUpApply();

        spriteRenderer.enabled = false;
    }

    protected virtual void PowerUpApply()
    {
        player.IsUsingPowerUp = true;
    }

    protected virtual void PowerUpExpired()
    {
        player.IsUsingPowerUp = false;
        OnPowerUpExpired.Raise(); // raise game event associated with expiration of power-ups
        DestroySelf();
    }

    protected void DestroySelf()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
        if (isInUse)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                isInUse = false;
                PowerUpExpired();
            }
        }
    }
}
