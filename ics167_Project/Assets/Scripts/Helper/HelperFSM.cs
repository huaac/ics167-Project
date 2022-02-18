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
    [SerializeField] private int helperAttack;
    private State currentState;

    [Header("Movement Settings")]
    [SerializeField] private Transform leadToFollow;
    [SerializeField] private float offset = 100f;
    [SerializeField] private Collider2D player1Collider;
    [SerializeField] private Collider2D player2Collider;
    private Vector2 homePosition;
    private Vector2 previousPosition;
    private float movement_x;

    [Header("Enemy Search Settings")]
    [SerializeField] private GameObject searchRange;
    [SerializeField] private BoxCollider2D hitbox;
    private EnemyDetector enemyDetector;
    private NavMeshAgent agent;
    private Enemy enemy;

    private Rigidbody2D rb;
    private BoxCollider2D selfCollider;
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
        selfCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Physics2D.IgnoreCollision(selfCollider, player1Collider);
        Physics2D.IgnoreCollision(selfCollider, player2Collider);
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
