using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// added in / edited by Alice Hua
// will be implemented later
[CreateAssetMenu(menuName = "SpiderFSM/Actions/Chase", order = 53)]
public class SpiderChase : BaseState
{
    private SpiderFSM sm;

    public SpiderChase(SpiderFSM stateMachine) : base("Chase", stateMachine) { 
        sm = stateMachine;
    }
}
