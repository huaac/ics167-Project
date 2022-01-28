using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_DoubleJump : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();

        // Payload is to give some health bonus
        player.EnableDoubleJump();
    }
}
