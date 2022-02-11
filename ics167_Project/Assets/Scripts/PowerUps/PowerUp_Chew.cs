using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

public class PowerUp_Chew : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.EnableChew();
    }

    protected override void PowerUpExpired()
    {
        player.DisableChew();
        base.PowerUpExpired();
    }
}
