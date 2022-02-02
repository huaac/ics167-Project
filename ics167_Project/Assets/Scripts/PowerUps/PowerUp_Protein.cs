using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama
// TODO: This power-up is not implemented yet

public class PowerUp_Protein : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();
        player.EnableProtein();
    }

    protected override void PowerUpExpired()
    {
        player.DisableProtein();
        base.PowerUpExpired();
    }
}
