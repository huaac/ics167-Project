using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Can Stop", order = 53)]
public class CanStopDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        GameObject possibleEnemy = machine.Hitbox.gameObject.GetComponent<EnemyDetector>().EnteredEnemy;

        if (possibleEnemy != null)
        {
            if (possibleEnemy.TryGetComponent(out UnkillableEnemy unkillable))
            {
                machine.Enemy = unkillable;
                return true;
            }
        }

        return false;
    }
}