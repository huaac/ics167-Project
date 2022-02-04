using UnityEngine;
using System.Collections;

// by Aissa Akiyama

public class PowerUp_WallJump : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.HasWallJump = true;
    }

    protected override void PowerUpExpired()
    {
        player.HasWallJump = false;
        base.PowerUpExpired();
    }
}
