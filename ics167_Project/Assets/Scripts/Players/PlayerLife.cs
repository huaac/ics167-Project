using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameEvent OnPlayerDied;

    private Rigidbody2D m_rb;
    private BoxCollider2D m_collider;
    private Animator m_anim;
    private PlayerState m_playerState;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_anim = GetComponent<Animator>();
        m_playerState = GetComponent<PlayerState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collision was with damageable object (killable enemy or chewable)
        // if so, we may need to do specific things
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            HitDamageable(collision.gameObject);
            return;
        }

        // check if collision was with enemy & die if it was
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    // play death animation, disable movement, raise OnPlayerDied event
    private void Die()
    {
        m_anim.SetTrigger("death");
        m_rb.bodyType = RigidbodyType2D.Static;
        m_collider.enabled = false;

        m_playerState.IsDead = true;
        OnPlayerDied.Raise();
    }

    private void HitDamageable(GameObject damageable)
    {
        // check if the gameobject player hit was killable enemy
        // attack the enemy if player has protein power-up; else die
        KillableEnemy killableenemy = damageable.GetComponent<KillableEnemy>();
        if (killableenemy != null)
        {
            if (m_playerState.HasProtein)
            {
                killableenemy.TakeDamage(50);
                return;
            }
            else
            {
                Die();
            }
        }

        // check if the gameobject player hit was chewable
        // chew through it if player has chew power-up
        ChewableObject chewableobject = damageable.GetComponent<ChewableObject>();
        if (chewableobject != null && m_playerState.HasChew)
        {
            chewableobject.TakeDamage(100);
            return;
        }
    }
}
