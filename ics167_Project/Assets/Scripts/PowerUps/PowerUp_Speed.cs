using UnityEngine;
using System.Collections;

// by Aissa Akiyama

public class PowerUp_Speed : PowerUp
{
    [SerializeField] private float speedIncrease;

    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.EnableSpeed(speedIncrease);
    }

    protected override void PowerUpExpired()
    {
        player.DisableSpeed();
        base.PowerUpExpired();
    }
}
