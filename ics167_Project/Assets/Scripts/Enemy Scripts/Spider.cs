using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// spiders can be killed in the future
// will have more functions in future playtest

public class Spider : KillableEnemy
{
    public Animator animator;
    //private SpriteRenderer m_sprite;

    public Transform detect_ground;
    public float speed;
    private bool facing_right;
    private float spider_wait_time;

    private void Awake()
    {
        //speed neg bc spider is facing right
        spider_wait_time =2f;
        speed = -4f;
        facing_right = true;
        animator.SetFloat("speed", 1);
        animator.SetBool("isDetected", false);
        //m_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(SeePrey())
        {
            Chase();
        }
        else{Patrol();}
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Patrol()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(detect_ground.position, Vector2.down, LayerMask.GetMask("jumpableGround"));
        if(groundInfo.collider == false)
        {
            // rn the spider immediately turns around when it reaches an edge.
            // should this be changed so that it doesnt turn until it moves again?
            StartCoroutine(WaitTime());
            if(facing_right)
            {
                //m_sprite.flipX = true;
                transform.eulerAngles = new Vector3(0,-180,0);
                facing_right = false;
            }
            else
            {
                //m_sprite.flipX = false;
                transform.eulerAngles = new Vector3(0,0,0);
                facing_right = true;
            }
        }
    }

    IEnumerator WaitTime()
    {
        speed = 0;
        animator.SetFloat("speed", 0);
        yield return new WaitForSeconds(spider_wait_time);
        speed = -4f;
        animator.SetFloat("speed", 1);
    }

    private bool SeePrey()
    {
        RaycastHit2D detected = Physics2D.Raycast(detect_ground.position, transform.TransformDirection(Vector2.left),5,LayerMask.GetMask("Player"));
        if(detected.collider){return true;}
        else {return false;}

    }

    IEnumerator Alerted()
    {
        speed = 0;
        animator.SetFloat("speed", 0);
        animator.SetBool("isDetected", true);
        yield return new WaitForSeconds(spider_wait_time);
        animator.SetBool("isDetected", false);
        speed = -6f;
        animator.SetFloat("speed", 1);
    }

    private void Chase()
    {
        StartCoroutine(Alerted());
        speed = -6f;
    }

    public override void Attack()
    {
    }

    //animator.SetBool("isDetected", true);
    //animator.SetFloat("speed", 1);

    // public override void OnCollisionEnter2D(Collision2D col)
    // {
    //     // if player touches spider, player falls down and reset scene
    //     /*
    //     if(col.gameObject.tag == "Player")
    //     {
    //         col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //         TakeDamage(50);
    //         CallResetScene();
    //     }
    //     */
    // }

    

}
