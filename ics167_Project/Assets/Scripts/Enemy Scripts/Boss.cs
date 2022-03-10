using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : KillableEnemy
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float chargeLength = 1f;
    [SerializeField] private float faintLength = 20f;
    private float movement_x;
    private Vector2 previousPosition;

    [SerializeField] private GameObject protein;
    [SerializeField] private float offset = 100f;

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

    private void Start()
    {
        m_anim.SetFloat("chargeLength", 20f);
        m_anim.SetFloat("faintLength", 20f);
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

    public void ReleasePowerUps()
    {
        GameObject go = (GameObject)Instantiate(protein,
            new Vector3(transform.position.x + offset,
                        transform.position.y,
                        0f),
            Quaternion.identity);

        go.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0f);

        GameObject go2 = (GameObject)Instantiate(protein,
            new Vector3(transform.position.x - offset,
                        transform.position.y,
                        0f),
            Quaternion.identity);

        go2.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0f);
    }

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

        m_anim.SetTrigger("wakeUp");
    }


    public Transform Left { get { return left; } }
    public Transform Right { get { return right; } }
}
