using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

public class PowerUp_Chew : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.HasChew = true;
    }

    protected override void PowerUpExpired()
    {
        player.HasChew = false;
        base.PowerUpExpired();
    }
}
