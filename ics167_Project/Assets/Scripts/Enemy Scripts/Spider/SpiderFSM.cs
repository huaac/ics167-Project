using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
// Taken from https://youtu.be/-VkezxxjsSE
public class SpiderFSM : StateMachine
{
    [HideInInspector]
    public SpiderMove move_state;
    [HideInInspector]
    public SpiderAlert alert_state;
    [HideInInspector]
    public SpiderIdle idle_state;
    [HideInInspector]
    public SpiderAttack attack_state;
    [SerializeField]
    private BoxCollider2D hitbox;

    //private Rigidbody2D rb;
    public float speed;
    public Transform detect_ground;
    public Animator animator;
    public bool facing_right;
    public bool in_sight;
    public bool powered_up;
    
    
    //public Transform transform;

    protected override void Awake()
    {
        move_state = new SpiderMove(this);
        alert_state = new SpiderAlert(this);
        idle_state = new SpiderIdle(this);
        attack_state = new SpiderAttack(this);
        animator = GetComponent<Animator>();
        speed = -4f;
        facing_right = true;
        in_sight = false;
        hitbox.enabled = false;
        base.Awake();
    }

    // must override from KillableEnemy class in order for health bar to work
    override public void TakeDamage(int damage) {base.TakeDamage(damage);}
    override protected void ChangeHealthBar(){base.ChangeHealthBar();}

    protected override BaseState GetInitialState()
    {
        animator.SetInteger("currentState", 1);
        return move_state;
    }

    public bool SeePrey()
    {
        RaycastHit2D detected = Physics2D.Raycast(detect_ground.position, transform.TransformDirection(Vector2.left),5,LayerMask.GetMask("Player"));
        if(detected.collider)
        {
            PlayerState FoundObject = GameObject.Find(detected.collider.gameObject.name).GetComponent<PlayerState>();
            powered_up = FoundObject.HasProtein;
            return true;
        }
        else
        {
            powered_up = false;
            in_sight = false;
            return false;
        }
        // if(sm.in_sight == false) {}
    }
    public bool InRange()
    {
        // if (Vector3.Distance(player.transform.position, transform.position) > distanceThresh)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        // }
        
        RaycastHit2D detected = Physics2D.Raycast(detect_ground.position, transform.TransformDirection(Vector2.left),(float)0.1,LayerMask.GetMask("Player"));
        if(detected.collider)
        {
            // PlayerState FoundObject = GameObject.Find(detected.collider.gameObject.name).GetComponent<PlayerState>();
            // powered_up = FoundObject.HasProtein;
            return true;
        }
        else{return false;}
    }

    public void SwipeAttack()
    {
        hitbox.enabled = true;
        // hitbox.enabled = false;
    }
    public void NoMoreSwipeAttack()
    {
        hitbox.enabled = true;
        // hitbox.enabled = false;
    }
}
