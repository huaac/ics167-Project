using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;       //added by Alice

// by Aissa Akiyama
// Implements player movement by using Input axes that can be set in the Input Manager for Project Settings.
// Also sets animation for the player's Animator to use depending on player's velocity.

// AudioManager by Mindy

public class PlayerMovementAissa : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private BoxCollider2D m_collider;
    private SpriteRenderer m_sprite;
    private Animator m_anim;
    private PlayerState m_playerState;

    [SerializeField] private GameEvent OnFinishReached;

    [Header("Input Settings")]
    [SerializeField] private string HorizontalAxis;
    [SerializeField] private string JumpButton;

    [Header("Movement Settings")]
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private float m_jumpSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;


    private enum AnimationState { idle, running, jumping, falling };

    private float movement_x = 0f;
    private float speedIncrease;
    private bool isDoubleJumping;
    private bool canWallJump;
    private Vector2 wallNormal;

    private bool finished;
    private Transform waitPos;
    private PhotonView view;            //added by Alice


    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
        m_playerState = GetComponent<PlayerState>();

        view = GetComponent<PhotonView>();      //added by Alice
    }   

    private void Update()
    {
        if (view && !view.IsMine)
            return;

        if (m_playerState.IsDead)
            return;

        if (m_playerState.HasFinished)
        {
            transform.position = Vector2.MoveTowards(transform.position, waitPos.position, 3f * Time.deltaTime);
            if (transform.position.x == waitPos.position.x && !finished)
            {
                OnFinishReached.Raise();
                finished = true;
            }

            return;
        }

        // horizontal movement
        movement_x = Input.GetAxisRaw(HorizontalAxis);
        m_rb.velocity = new Vector2(movement_x * m_moveSpeed * m_playerState.SpeedMultiplier, m_rb.velocity.y);

        // jump
        if (Input.GetButtonDown(JumpButton))
        {
            AudioManager.PlaySound("jump");
            if (IsGrounded())
            {
                m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpSpeed);
                isDoubleJumping = false;
            }
            else if (!IsGrounded() && m_playerState.HasDoubleJump)
            {
                if (!isDoubleJumping)
                {
                    // double jump only when player isn't already double jumping
                    m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpSpeed);
                    isDoubleJumping = true;
                }
            }
            // wall jump
            if (!IsGrounded() && m_playerState.HasWallJump && canWallJump)
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

    // A function that returns true if the player is on the ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(m_collider.bounds.center, m_collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    // A function that detects if a player can wall jump
    private void DetectWallJump(Vector2 normal)
    {
        if (!IsGrounded() && (normal == new Vector2(1f, 0f) || normal == new Vector2(-1f, 0f)))
        {
            // if player is not grounded + normals are horizontal (collision is against wall)
            canWallJump = true;
            wallNormal = normal;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            AudioManager.PlaySound("win");
            m_playerState.SetToFinished();

            collision.gameObject.TryGetComponent(out Finish finish);
            waitPos = finish.EmptyPosition();
        }
    }

    // enable/disable wall jump based on contact w/ wall
    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        DetectWallJump(normal);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 normal = new Vector2(0, 0);
        canWallJump = false;
    }

    //gets the flipping of the animator to show in networked coop
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)  //added my alice
    {
        if (stream.IsWriting)
        {
            stream.SendNext(m_sprite.flipX);
            // stream.SendNext(m_rb.position);
            // stream.SendNext(m_rb.position);
            // stream.SendNext(m_rb.velocity);
        }
        else
        {
            m_sprite.flipX = (bool)stream.ReceiveNext();
            // playerPos = (Vector2)stream.ReceiveNext();
            // m_rb.position = (Vector2) stream.ReceiveNext();
            // m_rb.velocity = (Vector2) stream.ReceiveNext();

            // float lag = Mathf.Abs((float) (PhotonNetwork.Time - info.timestamp));
            // m_rb.position += (this.m_rb.velocity * lag);
        }
    }
}
