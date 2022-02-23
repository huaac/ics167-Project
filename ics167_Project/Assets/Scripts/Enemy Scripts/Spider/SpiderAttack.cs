using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
// will be implemented later
[CreateAssetMenu(menuName = "SpiderFSM/Actions/Attack", order = 53)]
public class SpiderAttack : BaseState
{
    private SpiderFSM sm;

    public SpiderAttack(SpiderFSM stateMachine) : base("Attack", stateMachine) { 
        sm = stateMachine;
    }
}
