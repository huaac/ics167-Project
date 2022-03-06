using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
// will be implemented later
[CreateAssetMenu(menuName = "SpiderFSM/Actions/Attack", order = 53)]
public class SpiderAttack : BaseState
{
    private SpiderFSM sm;
    private float startTime;    // start time of when to check if spider was idle enough
    private float waitFor;      // wait time
    private bool timerStart;    // 
    [SerializeField]
    private BoxCollider2D hitbox;

    public SpiderAttack(SpiderFSM stateMachine) : base("Attack", stateMachine) { 
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        sm.speed = 0;                       // speed is 0 bc spider is idle
        sm.animator.SetInteger("currentState", 3);   // sets the animation
        timerStart = true;
        waitFor = .5f;;
        startTime = Time.time;
        sm.SwipeAttack();
    }

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
            // sm.in_sight = true;
            sm.NoMoreSwipeAttack();
            stateMachine.ChangeState(sm.move_state);
        }
    }

    public override void Exit()
    {base.Exit();}
}
