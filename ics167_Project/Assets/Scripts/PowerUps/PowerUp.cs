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
    protected SpriteRenderer m_sprite;
    protected BoxCollider2D m_collider;

    [SerializeField] private GameEvent OnPlayer1Collected;
    [SerializeField] private GameEvent OnPlayer1Expired;
    [SerializeField] private GameEvent OnPlayer2Collected;
    [SerializeField] private GameEvent OnPlayer2Expired;

    [SerializeField] private float timer = 5f;

    private bool isInUse;


    protected virtual void Awake()
    {
        m_collider = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
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


        if (player.PlayerID == 1)
            OnPlayer1Collected.Raise();
        else if (player.PlayerID == 2)
            OnPlayer2Collected.Raise();

        PowerUpApply();

        m_sprite.enabled = false;
        m_collider.enabled = false;
    }

    protected virtual void PowerUpApply()
    {
        player.IsUsingPowerUp = true;
    }

    protected virtual void PowerUpExpired()
    {
        player.IsUsingPowerUp = false;

        if (player.PlayerID == 1)
            OnPlayer1Expired.Raise();
        else if (player.PlayerID == 2)
            OnPlayer2Expired.Raise();

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
            if (timer < 0 || player.IsDead)
            {
                isInUse = false;
                PowerUpExpired();
            }
        }
    }
}
