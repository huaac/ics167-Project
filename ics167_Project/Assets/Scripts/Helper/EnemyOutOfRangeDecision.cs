using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Out of Range", order = 53)]
public class EnemyOutOfRangeDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        GameObject possibleEnemy = machine.Detector.EnteredEnemy;

        return possibleEnemy == null;
    }
}