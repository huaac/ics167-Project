using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Actions/Return", order = 53)]
public class ReturnAction : Action
{
    public override void Act(HelperFSM machine)
    {
        machine.Agent.SetDestination(new Vector3(machine.HomePosition.x,
                                                machine.HomePosition.y,
                                                0f));
    }
}
