using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected PlayerMovementAissa player;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger detected!");
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
