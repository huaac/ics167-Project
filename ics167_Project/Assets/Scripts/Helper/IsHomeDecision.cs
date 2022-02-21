using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

[CreateAssetMenu(menuName = "FSM/Decisions/Is Home", order = 53)]
public class IsHomeDecision : Decision
{
    public override bool Decide(HelperFSM machine)
    {
        Vector2 currentPos = new Vector2(machine.gameObject.transform.position.x,
                                        machine.gameObject.transform.position.y);

        return currentPos == machine.HomePosition;
    }
}