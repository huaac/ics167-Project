using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Decisions/Can Attack", order = 53)]
public class CanAttackDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        GameObject possibleEnemy = machine.Hitbox.gameObject.GetComponent<EnemyDetector>().EnteredEnemy;

        if (possibleEnemy != null)
        {
            if (possibleEnemy.TryGetComponent(out KillableEnemy killable))
            {
                machine.Enemy = killable;
                return true;
            }
        }

        return false;
    }
}