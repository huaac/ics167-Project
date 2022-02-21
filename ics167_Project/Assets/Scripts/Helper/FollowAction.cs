using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Actions/Follow", order = 53)]
public class FollowAction : Action
{
    public override void Act(HelperFSM machine)
    {
        machine.gameObject.transform.position = machine.HomePosition;
    }
}