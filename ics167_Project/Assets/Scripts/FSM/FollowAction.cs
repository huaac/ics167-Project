using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Follow", order = 53)]
public class FollowAction : Action
{
    public override void Act(HelperFSM machine)
    {
        machine.transform.position = machine.HomePosition;
    }
}