using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// by Aissa Akiyama
// Implements player movement by using Input axes that can be set in the Input Manager for Project Settings.
// Also sets animation for the player's Animator to use depending on player's velocity.
// There are booleans that can be set from PowerUp scripts to enable/disable certain types of movement.

public class PlayerMovementAissa : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private BoxCollider2D m_collider;
    private SpriteRenderer m_sprite;
    private Animator m_anim;
    private PlayerState m_playerState;

    // Restart and Menu Settings by Mindy Jun
    [Header("Restart and Menu Settings")]
    [SerializeField] private float levelRestartDelay;
    public GameObject optionsMenu;
    public GameObject dimImage;

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

    // bool's to enable/disable power ups
    /*private bool doubleJumpEnabled;
    private bool speedEnabled;
    private bool wallJumpEnabled;*/

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
        m_playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        // horizontal movement
        movement_x = Input.GetAxisRaw(HorizontalAxis);
        m_rb.velocity = new Vector2(movement_x * m_moveSpeed * m_playerState.SpeedMultiplier, m_rb.velocity.y);
        //if (m_playerState.HasSpeed)
        //    m_rb.velocity = new Vector2(movement_x * m_moveSpeed * m_playerState.SpeedMultiplier, m_rb.velocity.y);

        // jump
        if (Input.GetButtonDown(JumpButton))
        {
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

        // Restart and Escape functionality by Mindy Jun
        if (Input.GetButtonDown("Restart")) 
        {
            ResetScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
            dimImage.gameObject.SetActive(!dimImage.gameObject.activeSelf);
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

    // by Mindy Jun
    // If a player collides with the finishing hole, the next level is loaded.
    // The next level is also unlocked in the level picking screen.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GameManager.Instance.completedLevels += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked")) 
            {
                PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        DetectWallJump(normal);
    }

    // Resets current level
    public void ResetScene()
    {
        StartCoroutine(ResetAfterDelay(levelRestartDelay));
    }

    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
