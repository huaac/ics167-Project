using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;                       //added by Alice for network

/// <summary>
/// by Aissa Akiyama
/// A class that manages the player's death.
/// When a player hits an enemy, it either dies or instead kills it if it is a killable enemy
/// and the player has the protein powerup.
/// The player also dies when the other player dies.
/// </summary>

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameEvent OnPlayerDied;
    [SerializeField] private int attack = 50;

    private Rigidbody2D m_rb;
    private BoxCollider2D m_collider;
    private Animator m_anim;
    private PlayerState m_playerState;

    private PhotonView view;            //added by Alice

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        m_anim = GetComponent<Animator>();
        m_playerState = GetComponent<PlayerState>();

        view = GetComponent<PhotonView>();      //added by Alice
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collision was with damageable object (killable enemy or chewable)
        // if so, we may need to do specific things
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            HitDamageable(collision.gameObject);
            return;
        }

        // check if collision was with enemy & die if it was
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
            // view.RPC("Die", RpcTarget.All); //added by Alice for network (not working)
        }
    }

    // play death animation, disable movement, raise OnPlayerDied event
    public void Die()
    {
        if (!m_playerState.IsDead)
        {
            m_anim.SetTrigger("death");
            m_rb.bodyType = RigidbodyType2D.Static;
            m_collider.enabled = false;

            m_playerState.SetToDead();
            OnPlayerDied.Raise();
            
        }
    }

    private void HitDamageable(GameObject damageable)
    {
        // check if the gameobject player hit was killable enemy
        // attack the enemy if player has protein power-up; else die
        if (damageable.TryGetComponent(out KillableEnemy killable))
        {
            if (m_playerState.HasProtein)
            {
                killable.TakeDamage(attack);
                return;
            }
            else
            {
                Die();
            }
        }

        // check if the gameobject player hit was chewable
        // chew through it if player has chew power-up
        if (damageable.TryGetComponent(out ChewableObject chewable) && m_playerState.HasChew)
        {
            chewable.TakeDamage(100);
            return;
        }
    }
}
