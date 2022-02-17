using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// by Aissa Akiyama
/// A script to control the state of the Helper.
/// </summary>

public class HelperFSM : MonoBehaviour
{
    [SerializeField] private State initialState;
    private State currentState;

    [SerializeField] private Transform leadToFollow;
    [SerializeField] private float offset = 100f;
    private Vector2 homePosition;
    private Vector2 previousPosition;
    private float movement_x;

    [SerializeField] private GameObject searchRange;
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private int helperAttack;
    private EnemyDetector enemyDetector;
    private NavMeshAgent agent;
    private Enemy enemy;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private void Awake()
    {
        currentState = initialState;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        enemyDetector = searchRange.GetComponent<EnemyDetector>();

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        homePosition = new Vector2(leadToFollow.position.x,
                                   leadToFollow.position.y + offset);

        // flip sprite according to velocity
        if (movement_x >= 0f)
        {
            hitbox.offset = new Vector2(0.3f, hitbox.offset.y);
            sprite.flipX = false;
        }
        else
        {
            hitbox.offset = new Vector2(-0.3f, hitbox.offset.y);
            sprite.flipX = true;
        }

        currentState.Execute(this);
    }

    private void LateUpdate()
    {
        movement_x = transform.position.x - previousPosition.x;
        previousPosition = transform.position;
    }

    // When transitioning to a new state, always call the Exit() of the old state,
    // then call the Enter() of the new state.
    public void TransitionState(State newState)
    {
        Debug.Log("from " + currentState + " to " + newState);
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    // Very stupid but this Attack function needs to be here so that the Helper only
    // attacks the enemy during specific frames of the attack animation. This needs to
    // be an attack during the animation (look at the helperAttack Animation).
    public void Attack()
    {
        if (enemy)
        {
            enemy.ApplyHelperAttack(helperAttack);
        }
    }


    public Vector2 HomePosition
    {
        get { return homePosition; }
    }

    public float Offset
    {
        get { return offset; }
    }

    public EnemyDetector Detector
    {
        get { return enemyDetector; }
    }

    public BoxCollider2D Hitbox
    {
        get { return hitbox; }
    }

    public int HelperAttack
    {
        get { return helperAttack; }
    }

    public NavMeshAgent Agent
    {
        get { return agent; }
    }

    public Enemy Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }

    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }
}
