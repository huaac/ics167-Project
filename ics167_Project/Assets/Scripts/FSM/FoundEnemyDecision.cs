using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Found Enemy")]
public class FoundEnemyDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        GameObject possibleEnemy = machine.SearchRange.GetComponent<EnemyDetector>().EnteredEnemy;

        return possibleEnemy != null;
    }
}
