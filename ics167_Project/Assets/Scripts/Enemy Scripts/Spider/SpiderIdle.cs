 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpiderFSM/Actions/Idle", order = 53)]
public class SpiderIdle : BaseState
{
    private SpiderFSM sm;
    private float startTime;
    private float waitFor;
    private bool timerStart;

    public SpiderIdle(SpiderFSM stateMachine) : base("Idle", stateMachine) { 
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        sm.speed = 0;
        sm.animator.SetFloat("speed", 0);
        timerStart = true;
        waitFor = 2f;
        startTime = Time.time;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if((timerStart == true) && (Time.time - startTime > waitFor))
        {
            //sm.speed = -4f;
            // sm.animator.SetFloat("speed", 1);
            timerStart = false;
        }

        if(timerStart == false)
        {
            stateMachine.ChangeState(sm.move_state);
        }
    }

    public override void Exit()
    {base.Exit();}

    // public override void UpdatePhysics()
    // {
    //     base.UpdatePhysics();
    //     //WaitTime();
    // }

    // private void WaitTime()
    // {
    //     sm.speed = 0;
    //     sm.animator.SetFloat("speed", 0);
    //     //yield return new WaitForSeconds(2f);
    //     timerStart = true;
    // }
}