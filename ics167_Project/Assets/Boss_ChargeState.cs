using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ChargeState : StateMachineBehaviour
{
    [SerializeField] private float m_speed = 2.5f;
    private float left;
    private float right;

    private Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        left = boss.Left.position.x;
        right = boss.Right.position.x;

        boss.StartChargeTimer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.transform.position = new Vector2(
            Mathf.PingPong(Time.time * m_speed, right - left) + left,
            boss.transform.position.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("faint");
        boss.ReleasePowerUps();
    }
}
