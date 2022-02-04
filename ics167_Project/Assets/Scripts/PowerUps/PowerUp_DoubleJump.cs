using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

public class PowerUp_DoubleJump : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.HasDoubleJump = true;
    }

    protected override void PowerUpExpired()
    {
        player.HasDoubleJump = false;
        base.PowerUpExpired();
    }
}
