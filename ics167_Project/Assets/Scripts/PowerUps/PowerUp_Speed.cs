using UnityEngine;
using System.Collections;

// by Aissa Akiyama

public class PowerUp_Speed : PowerUp
{
    [SerializeField] private float speedIncrease;

    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        //player.HasSpeed = true;
        player.SpeedMultiplier = speedIncrease;
    }

    protected override void PowerUpExpired()
    {
        //player.HasSpeed = false;
        player.SpeedMultiplier = 1f;
        base.PowerUpExpired();
    }
}
