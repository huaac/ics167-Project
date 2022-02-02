using UnityEngine;
using System.Collections;

// by Aissa Akiyama

public class PowerUp_WallJump : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.EnableWallJump();
    }

    protected override void PowerUpExpired()
    {
        player.DisableWallJump();
        base.PowerUpExpired();
    }
}
