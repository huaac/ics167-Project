 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
[CreateAssetMenu(menuName = "SpiderFSM/Actions/Idle", order = 53)]
public class SpiderIdle : BaseState
{
    private SpiderFSM sm;
    private float startTime;    // start time of when to check if spider was idle enough
    private float waitFor;      // wait time
    private bool timerStart;    // 

    public SpiderIdle(SpiderFSM stateMachine) : base("Idle", stateMachine) { 
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        sm.speed = 0;                       // speed is 0 bc spider is idle
        sm.animator.SetFloat("speed", 0);   // sets the animation
        timerStart = true;
        waitFor = 2f;
        startTime = Time.time;
    }

    // if spider waited 2 seconds, then transition back to moving state
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if((timerStart == true) && (Time.time - startTime > waitFor))
        {
            timerStart = false;
        }

        if(timerStart == false)
        {
            stateMachine.ChangeState(sm.move_state);
        }
    }

    public override void Exit()
    {base.Exit();}

}