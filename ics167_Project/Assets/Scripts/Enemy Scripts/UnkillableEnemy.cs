using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua

public abstract class UnkillableEnemy : Enemy
{
    //Freeze and Unfreeze method that the helper can call upon to aid the player
    public abstract void Freeze();
    public abstract void UnFreeze();

    protected override void OnHelperAttack(int damage)
    {
        Freeze();
    }
}
