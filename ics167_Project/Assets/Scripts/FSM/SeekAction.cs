using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Seek", order =53)]
public class SeekAction : Action
{
    public override void Act(HelperFSM machine)
    {
        GameObject target = GetTarget(machine);
        if (target)
        {
            machine.Agent.SetDestination(new Vector3(target.transform.position.x,
                                                target.transform.position.y,
                                                0f));
        }
    }

    private GameObject GetTarget(HelperFSM machine)
    {
        return machine.SearchRange.GetComponent<EnemyDetector>().EnteredEnemy;
    }
}

