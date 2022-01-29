using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected PlayerMovementAissa player;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] private GameEvent OnPowerUpCollected;


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

        OnPowerUpCollected.Raise();
        PowerUpApply();

        spriteRenderer.enabled = false;
    }

    protected virtual void PowerUpApply()
    {
        DestroySelf();
    }

    protected void DestroySelf()
    {
        Destroy(gameObject);
    }
}
