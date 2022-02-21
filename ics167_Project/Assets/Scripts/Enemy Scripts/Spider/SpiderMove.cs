using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SpiderFSM/Actions/Move", order = 53)]
public class SpiderMove : BaseState
{
    private SpiderFSM sm;
    private bool turned;
    private bool powered_up;

    public SpiderMove(SpiderFSM stateMachine) : base("Move", stateMachine) { 
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        sm.speed = -4f;
        turned = false;
        sm.animator.SetFloat("speed", 1);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(SeePrey()) 
        {
            sm.speed = -10f;
            if(powered_up){FlipSprite();}
        }
        if(turned) {stateMachine.ChangeState(sm.idle_state);}
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Move();
    }

    private void Move()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(sm.detect_ground.position, Vector2.down,1, LayerMask.GetMask("jumpableGround"));
        if(groundInfo.collider == false)
        {
            // rn the spider immediately turns around when it reaches an edge.
            // should this be changed so that it doesnt turn until it moves again?

            //instance.StartCoroutine(WaitTime());
            FlipSprite();
            // if(sm.facing_right)
            // {
            //     //m_sprite.flipX = true;
            //     sm.transform.eulerAngles = new Vector3(0,-180,0);
            //     sm.facing_right = false;
            // }
            // else
            // {
            //     //m_sprite.flipX = false;
            //     sm.transform.eulerAngles = new Vector3(0,0,0);
            //     sm.facing_right = true;
            // }

            turned = true;
        }
        sm.transform.Translate(Vector2.right * sm.speed * Time.deltaTime);
    }

    private bool SeePrey()
    {
        RaycastHit2D detected = Physics2D.Raycast(sm.detect_ground.position, sm.transform.TransformDirection(Vector2.left),5,LayerMask.GetMask("Player"));
        if(detected.collider)
        {
            PlayerState FoundObject = GameObject.Find(detected.collider.gameObject.name).GetComponent<PlayerState>();
            powered_up = FoundObject.HasProtein;
            //if(detected.collider.gameObject.HasProtein) {powered_up = true;}
            return true;
        }
        else
        {
            powered_up = false;
            return false;
        }
    }

    private void FlipSprite()
    {
        if(sm.facing_right)
        {
            //m_sprite.flipX = true;
            sm.transform.eulerAngles = new Vector3(0,-180,0);
            sm.facing_right = false;
        }
        else
        {
            //m_sprite.flipX = false;
            sm.transform.eulerAngles = new Vector3(0,0,0);
            sm.facing_right = true;
        }
    }

    public override void Exit()
    {base.Exit();}
}
