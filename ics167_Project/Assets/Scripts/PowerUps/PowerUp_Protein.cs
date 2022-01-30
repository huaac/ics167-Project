using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Protein : PowerUp
{
    protected override void PowerUpApply()
    {
        base.PowerUpApply();

        // Payload is to give some health bonus
        player.EnableProtein();
    }

    protected override void PowerUpExpired()
    {
        player.DisableProtein();
        base.PowerUpExpired();
    }
}
