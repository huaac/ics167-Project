using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAissa : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private BoxCollider2D m_collider;
    private SpriteRenderer m_sprite;
    private Animator m_anim;

    [Header("input settings")]
    [SerializeField] private string HorizontalAxis;
    [SerializeField] private string JumpAxis;

    [Header("movement settings")]
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private float m_jumpSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;

    private enum AnimationState { idle, running, jumping, falling };

    private float movement_x = 0f;
    private bool jumpButtonDown;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
    }

    private void Start()
    {
        jumpButtonDown = false;
    }

    private void Update()
    {
        // horizontal movement
        movement_x = Input.GetAxisRaw(HorizontalAxis);
        m_rb.velocity = new Vector2(movement_x * m_moveSpeed, m_rb.velocity.y);

        // jump
        if (Input.GetAxisRaw(JumpAxis) != 0 && IsGrounded())
        {
            // if jump button is pressed + player is on ground
            if (!jumpButtonDown)
            {
                // if jump button is not already pressed
                // (need to check because GetAxisRaw responds for the duration of when a button is held,
                // not just the moment it is pressed down)
                m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpSpeed);
            }
            jumpButtonDown = true;
        }
        else
        {
            jumpButtonDown = false;
        }

        UpdateAnimation();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(m_collider.bounds.center, m_collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void UpdateAnimation()
    {
        // For updating animation, I can either keep track of a bunch of bool's for each animation, or choose from
        // an enum of animation states. Not sure which is going to scale when we add death animation + logic

        AnimationState state;

        // check for idle/running
        if (movement_x > 0f)
        {
            state = AnimationState.running;
            m_sprite.flipX = false;
        }
        else if (movement_x < 0f)
        {
            state = AnimationState.running;
            m_sprite.flipX = true;
        }
        else
        {
            state = AnimationState.idle;
        }

        // check for jumping/falling
        if (m_rb.velocity.y > 0.01f)
        {
            state = AnimationState.jumping;
        }
        else if (m_rb.velocity.y < -0.01f)
        {
            state = AnimationState.falling;
        }

        m_anim.SetInteger("currentState", (int)state);
    }
}
