using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected PlayerMovementAissa player;
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
        player = gameObjectCollectingPowerUp.GetComponent<PlayerMovementAissa>();

        // check if colliding object was player
        if (!player)
        {
            return;
        }
        // check if we haven't been collected before
        if (isInUse)
        {
            return;
        }
        isInUse = true;

        OnPowerUpCollected.Raise();
        PowerUpApply();

        spriteRenderer.enabled = false;
    }

    protected virtual void PowerUpApply()
    {
        
    }

    protected virtual void PowerUpExpired()
    {
        OnPowerUpExpired.Raise();
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
