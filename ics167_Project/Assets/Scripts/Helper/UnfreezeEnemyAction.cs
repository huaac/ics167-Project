using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Actions/Unfreeze Enemy", order = 53)]
public class UnfreezeEnemyAction : Action
{
    public override void Act(HelperFSM machine)
    {
        if (machine.Enemy)
        {
            if (machine.Enemy.gameObject.TryGetComponent(out UnkillableEnemy unkillable))
            {
                unkillable.UnFreeze();
            }
        }
    }
}
