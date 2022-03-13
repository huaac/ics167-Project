using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// A simple script for the Boss. State transitions are done using Unity's built-in Animator
/// state machines.
/// </summary>

public class Boss : KillableEnemy
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float chargeLength = 20f;
    [SerializeField] private float faintLength = 20f; // should be slightly longer than powerup length
    private float movement_x;
    private Vector2 previousPosition;

    [Header("PowerUp Spawn Settings")]
    [SerializeField] private GameObject protein;
    [SerializeField] private float offset = 2f;

    [Header("Finish Spawn Settings")]
    [SerializeField] private GameObject finish;
    [SerializeField] private float finishY;

    private Rigidbody2D m_rb;
    private BoxCollider2D m_col;
    private SpriteRenderer m_sprite;
    private Animator m_anim;

    private void Awake()
    {
        base.Awake();

        m_rb = GetComponent<Rigidbody2D>();
        m_col = GetComponent<BoxCollider2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // flip sprite according to velocity
        if (movement_x >= 0f)
        {
            m_sprite.flipX = false;
        }
        else
        {
            m_sprite.flipX = true;
        }
    }

    private void LateUpdate()
    {
        movement_x = transform.position.x - previousPosition.x;
        previousPosition = transform.position;
    }

    // Charge for a pre-determined amount of time
    public void StartChargeTimer()
    {
        StartCoroutine(ChargeTimer());
    }
    private IEnumerator ChargeTimer()
    {
        float timer = chargeLength;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }

        m_anim.SetTrigger("faint");
    }

    // Release powerups that can be used to attack the boss while it is fainting
    public void ReleasePowerUps()
    {
        // release 1 protein to right
        GameObject go = (GameObject)Instantiate(protein,
            new Vector3(transform.position.x + offset,
                        transform.position.y,
                        0f),
            Quaternion.identity);

        go.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0f);

        // release 1 protein to left
        GameObject go2 = (GameObject)Instantiate(protein,
            new Vector3(transform.position.x - offset,
                        transform.position.y,
                        0f),
            Quaternion.identity);

        go2.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0f);
    }
    // Erase power ups left in scene so players can't attack boss while it's charging
    public void ErasePowerUps()
    {
        var powerups = FindObjectsOfType<PowerUp>();
        foreach (PowerUp pu in powerups)
        {
            Destroy(pu.gameObject);
        }
    }

    // Faint for a pre-determined amount of time
    public void StartFaintTimer()
    {
        StartCoroutine(FaintTimer());
    }
    private IEnumerator FaintTimer()
    {
        float timer = faintLength;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }

        // things to do when boss is done fainting
        m_anim.SetTrigger("wakeUp");
    }


    protected override void Die()
    {
        m_anim.SetTrigger("death");
        ReleaseFinish();
        base.Die();
    }
    private void ReleaseFinish()
    {
        /*
        GameObject go = (GameObject)Instantiate(finish,
            new Vector3(transform.position.x,
                        finishY,
                        0f),
            Quaternion.identity);*/
        finish.SetActive(true);
    }


    public Transform Left { get { return left; } }
    public Transform Right { get { return right; } }
}
