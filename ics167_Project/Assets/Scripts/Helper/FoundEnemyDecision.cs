using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Decisions/Found Enemy", order = 53)]
public class FoundEnemyDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        GameObject possibleEnemy = machine.Detector.EnteredEnemy;

        return possibleEnemy != null;
    }
}
