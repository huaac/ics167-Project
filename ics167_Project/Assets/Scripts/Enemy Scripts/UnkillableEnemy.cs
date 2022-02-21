using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua

public abstract class UnkillableEnemy : Enemy
{
    //Nothing rn but will add when we put in more functions
    public abstract void Freeze();
    public abstract void UnFreeze();

    protected override void OnHelperAttack(int damage)
    {
        Freeze();
    }
}
