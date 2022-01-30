using UnityEngine;
using System.Collections;

public class PowerUp_WallJump : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();

        // Payload is to give some health bonus
        player.EnableWallJump();
    }

    protected override void PowerUpExpired()
    {
        player.DisableWallJump();
        base.PowerUpExpired();
    }
}
