using UnityEngine;
using System.Collections;

public class PowerUp_Speed : PowerUp
{
    [SerializeField] private float speedIncrease;

    protected override void PowerUpApply()
    {
        base.PowerUpApply();

        // Payload is to give some health bonus
        player.EnableSpeed(speedIncrease);
    }

    protected override void PowerUpExpired()
    {
        player.DisableSpeed();
        base.PowerUpExpired();
    }
}
