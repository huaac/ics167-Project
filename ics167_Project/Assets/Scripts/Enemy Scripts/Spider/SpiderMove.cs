using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
[CreateAssetMenu(menuName = "SpiderFSM/Actions/Move", order = 53)]
public class SpiderMove : BaseState
{
    private SpiderFSM sm;
    private bool turned;
    // private bool powered_up;

    public SpiderMove(SpiderFSM stateMachine) : base("Move", stateMachine) { 
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        sm.speed = -4f;     // sets walking speed
        turned = false;     //checks if the sprite flipped
        sm.animator.SetInteger("currentState", 1);   // sets animation to walking
    }

    // if spider sees players, then increase speed to simulate charging, else if
    // it reaches an edge, it turns and pauses for a bit
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(sm.SeePrey()) 
        {
            // sm.speed = -10f;
            if(sm.powered_up){FlipSprite();}
            else if (!sm.in_sight)
            {
                stateMachine.ChangeState(sm.alert_state);
            }
            else
            {
                if(sm.InRange()) {stateMachine.ChangeState(sm.attack_state);}
                else {sm.speed = -10f;}
            } //charge if already in sight
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
    // private bool SeePrey()
    // {
    //     RaycastHit2D detected = Physics2D.Raycast(sm.detect_ground.position, sm.transform.TransformDirection(Vector2.left),5,LayerMask.GetMask("Player"));
    //     if(detected.collider)
    //     {
    //         PlayerState FoundObject = GameObject.Find(detected.collider.gameObject.name).GetComponent<PlayerState>();
    //         powered_up = FoundObject.HasProtein;
    //         return true;
    //     }
    //     else
    //     {
    //         powered_up = false;
    //         sm.in_sight = false;
    //         return false;
    //     }
    //     // if(sm.in_sight == false) {}
    // }

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

    // private bool InRange()
    // {
    //     // if (Vector3.Distance(player.transform.position, transform.position) > distanceThresh)
    //     // {
    //     //     transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    //     // }
        
    //     RaycastHit2D detected = Physics2D.Raycast(detect_ground.position, transform.TransformDirection(Vector2.left),1,LayerMask.GetMask("Player"));
    //     if(detected.collider)
    //     {
    //         // PlayerState FoundObject = GameObject.Find(detected.collider.gameObject.name).GetComponent<PlayerState>();
    //         // powered_up = FoundObject.HasProtein;
    //         return true;
    //     }
    //     else{return false;}
    // }

    // IEnumerator startAlert()
    // {
    //     sm.animator.SetTrigger("alert");
    //     yield return new WaitForSeconds(2f);
    //     sm.animator.ResetTrigger("alert");
    // }

    public override void Exit() {base.Exit();}
}
