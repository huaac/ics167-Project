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
    public SpiderChase chase_state;
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
    
    
    //public Transform transform;

    protected override void Awake()
    {
        move_state = new SpiderMove(this);
        chase_state = new SpiderChase(this);
        idle_state = new SpiderIdle(this);
        attack_state = new SpiderAttack(this);
        animator = GetComponent<Animator>();
        speed = -4f;
        facing_right = true;
        base.Awake();
    }

    // must override from KillableEnemy class in order for health bar to work
    override public void TakeDamage(int damage) {base.TakeDamage(damage);}
    override protected void ChangeHealthBar(){base.ChangeHealthBar();}

    protected override BaseState GetInitialState()
    {
        return move_state;
    }
}
