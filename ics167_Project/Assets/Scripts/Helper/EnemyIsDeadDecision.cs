using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Enemy Is Dead", order = 53)]
public class EnemyIsDeadDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        return machine.Enemy == null;
    }
}
