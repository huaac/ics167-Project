using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
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
        sm.speed = -4f;     // sets walking speed
        turned = false;     //checks if the sprite flipped
        sm.animator.SetFloat("speed", 1);   // sets animation to walking
    }

    // if spider sees players, then increase speed to simulate charging, else if
    // it reaches an edge, it turns and pauses for a bit
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

    // simulates spider walking and turns if it reaches an edge on platform
    private void Move()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(sm.detect_ground.position, Vector2.down,1, LayerMask.GetMask("jumpableGround"));
        if(groundInfo.collider == false)
        {
            FlipSprite();
            turned = true;
        }
        sm.transform.Translate(Vector2.right * sm.speed * Time.deltaTime);
    }

    // detects if players are in view of the spider
    private bool SeePrey()
    {
        RaycastHit2D detected = Physics2D.Raycast(sm.detect_ground.position, sm.transform.TransformDirection(Vector2.left),5,LayerMask.GetMask("Player"));
        if(detected.collider)
        {
            PlayerState FoundObject = GameObject.Find(detected.collider.gameObject.name).GetComponent<PlayerState>();
            powered_up = FoundObject.HasProtein;
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
            sm.transform.eulerAngles = new Vector3(0,-180,0);
            sm.facing_right = false;
        }
        else
        {
            sm.transform.eulerAngles = new Vector3(0,0,0);
            sm.facing_right = true;
        }
    }

    public override void Exit() {base.Exit();}
}
