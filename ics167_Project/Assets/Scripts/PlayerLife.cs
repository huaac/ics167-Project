using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private PlayerState m_playerState;

    private void Awake()
    {
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

    protected void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private void Die()
    {
        // do something when player dies... right now this logic was copy-pasted from Alice's enemy scripts
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("ResetScene", 1f);

        return;
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

    /*
    public void EnableProtein() { proteinEnabled = true; }
    public void DisableProtein() { proteinEnabled = false; }

    public void EnableChew() { chewEnabled = true; }
    public void DisableChew() { chewEnabled = false; }
    */
}
