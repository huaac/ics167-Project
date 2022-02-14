using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/FoundEnemy", order = 53)]
public class FoundEnemyDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        GameObject possibleEnemy = machine.SearchRange.GetComponent<EnemyDetector>().EnteredEnemy;

        return possibleEnemy != null;
    }
}