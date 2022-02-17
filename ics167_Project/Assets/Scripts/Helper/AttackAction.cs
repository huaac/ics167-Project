using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Attack", order = 53)]
public class AttackAction : Action
{
    public override void Act(HelperFSM machine)
    {
        if (machine.Enemy)
            machine.Enemy.ApplyHelperAttack(machine.HelperAttack);
    }
}