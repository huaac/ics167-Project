using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpiderFSM/Actions/Chase", order = 53)]
public class SpiderChase : BaseState
{
    private SpiderFSM sm;

    public SpiderChase(SpiderFSM stateMachine) : base("Chase", stateMachine) { 
        sm = stateMachine;
    }

    // public override void Enter()
    // {
    //     base.Enter();
    //     sm.speed = -6f;
    //     sm.animator.SetFloat("speed", 1);
    // }

    // public override void UpdateLogic()
    // {
    //     //if target in range, then attack
    //     base.UpdateLogic();
    //     if(target_in_range) {stateMachine.ChangeState(sm.attack_state);}
    // }

    // public override void UpdatePhysics()
    // {
    //     base.UpdatePhysics();
    //     Move();
    // }

    // private void Move()
    // {
    //     sm.transform.Translate(Vector2.right * sm.speed * Time.deltaTime);
    // }
}
