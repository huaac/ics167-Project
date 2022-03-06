using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// added in / edited by Alice Hua
// will be implemented later
[CreateAssetMenu(menuName = "SpiderFSM/Actions/Alert", order = 53)]
public class SpiderAlert : BaseState
{
    private SpiderFSM sm;
    private float startTime;    // start time of when to check if spider was idle enough
    private float waitFor;      // wait time
    private bool timerStart;    // 

    public SpiderAlert(SpiderFSM stateMachine) : base("Alert", stateMachine) { 
        sm = stateMachine;
    }

     public override void Enter()
    {
        base.Enter();
        sm.speed = 0;     // sets walking speed
        sm.animator.SetInteger("currentState", 2);   // sets animation to walking
        // sm.animator.SetTrigger("alert");
        timerStart = true;
        waitFor = .5f;
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
            // sm.animator.ResetTrigger("alert");
            sm.in_sight = true;
            stateMachine.ChangeState(sm.move_state);
        }
    }

    public override void Exit()
    {base.Exit();}


}
