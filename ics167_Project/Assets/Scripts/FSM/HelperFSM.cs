using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HelperFSM : MonoBehaviour
{
    [SerializeField] private State initialState;
    private State currentState;

    [SerializeField] private Transform player1;
    [SerializeField] private float offset;
    private Vector2 homePosition;

    [SerializeField] private GameObject searchRange;
    private NavMeshAgent agent;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private enum HelperState { idle, running, attack };

    private void Awake()
    {
        currentState = initialState;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        homePosition = new Vector2(player1.position.x,
                                   player1.position.y + offset);

        // flip sprite according to velocity
        if (rb.velocity.x > 0f)
        {
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0f)
        {
            sprite.flipX = true;
        }

        currentState.Execute(this);
    }

    public void TransitionState(State newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }


    public Transform PlayerPos
    {
        get { return player1; }
    }

    public Vector2 HomePosition
    {
        get { return homePosition; }
    }

    public float Offset
    {
        get { return offset; }
    }

    public GameObject SearchRange
    {
        get { return searchRange; }
    }

    public NavMeshAgent Agent
    {
        get { return agent; }
    }

    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }
}
