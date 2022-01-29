using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAissa : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private BoxCollider2D m_collider;
    private SpriteRenderer m_sprite;
    private Animator m_anim;

    [Header("Input Settings")]
    [SerializeField] private string HorizontalAxis;
    [SerializeField] private string JumpButton;

    [Header("Movement Settings")]
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private float m_jumpSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private GameEvent OnPowerUpExpired;

    private enum AnimationState { idle, running, jumping, falling };

    private float movement_x = 0f;
    private float speedIncrease;
    private bool isDoubleJumping;
    private bool canWallJump;
    private Vector2 wallNormal;

    // bool's to enable/disable power ups
    private bool doubleJumpEnabled;
    private bool speedEnabled;
    private bool wallJumpEnabled;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // horizontal movement
        movement_x = Input.GetAxisRaw(HorizontalAxis);
        m_rb.velocity = new Vector2(movement_x * m_moveSpeed, m_rb.velocity.y);
        if (speedEnabled)
            m_rb.velocity = new Vector2(movement_x * m_moveSpeed * speedIncrease, m_rb.velocity.y);

        // jump
        if (Input.GetButtonDown(JumpButton))
        {
            if (IsGrounded())
            {
                m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpSpeed);
                isDoubleJumping = false;
            }
            else if (!IsGrounded() && doubleJumpEnabled)
            {
                if (!isDoubleJumping)
                {
                    m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpSpeed);
                    isDoubleJumping = true;
                }
            }

            if (!IsGrounded() && wallJumpEnabled && canWallJump)
            {
                m_rb.velocity = new Vector2(m_rb.velocity.x * wallNormal.x, m_jumpSpeed);
                canWallJump = false;
            }
        }

        UpdateAnimation();
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

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(m_collider.bounds.center, m_collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        if (!IsGrounded() && (normal == new Vector2(1f, 0f) || normal == new Vector2(-1f, 0f)))
        {
            // if player is not grounded + normals are horizontal (collision is against wall)
            canWallJump = true;
            wallNormal = normal;
        }
    }


    // enabling/disabling power ups
    public void EnableDoubleJump()
    {
        doubleJumpEnabled = true;
    }
    public void DisableDoubleJump()
    {
        doubleJumpEnabled = false;
    }

    public void EnableSpeed(float speedIncreaseAmount)
    {
        speedEnabled = true;
        speedIncrease = speedIncreaseAmount;
    }
    public void DisableSpeed()
    {
        speedEnabled = false;
    }

    public void EnableWallJump()
    {
        wallJumpEnabled = true;
    }
    public void DisableWallJump()
    {
        wallJumpEnabled = false;
    }

}
