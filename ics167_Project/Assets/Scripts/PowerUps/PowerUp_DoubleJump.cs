using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

public class PowerUp_DoubleJump : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.EnableDoubleJump();
    }

    protected override void PowerUpExpired()
    {
        player.DisableDoubleJump();
        base.PowerUpExpired();
    }
}
