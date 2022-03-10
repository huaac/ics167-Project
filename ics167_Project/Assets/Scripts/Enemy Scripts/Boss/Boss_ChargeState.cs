using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama

public class Boss_ChargeState : StateMachineBehaviour
{
    [SerializeField] private float m_speed = 0.5f;
    private float left;
    private float right;
    private float t;
    private float dir = -1;

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
        // move boss back and forth between left/right positions
        boss.transform.position = new Vector2(
            Mathf.Lerp(right, left, t),
            boss.transform.position.y);

        t += Time.deltaTime * m_speed * dir;
        if (t <= 0 || t >= 1)
        {
            if (t <= 0)
                t = 0;
            else if (t >= 1)
                t = 1;
            dir *= -1;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("faint");
        boss.ReleasePowerUps();
    }
}
