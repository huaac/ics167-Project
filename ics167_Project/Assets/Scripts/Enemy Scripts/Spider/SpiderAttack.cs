using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpiderFSM/Actions/Attack", order = 53)]
public class SpiderAttack : BaseState
{
    private SpiderFSM sm;

    public SpiderAttack(SpiderFSM stateMachine) : base("Attack", stateMachine) { 
        sm = stateMachine;
    }
}
