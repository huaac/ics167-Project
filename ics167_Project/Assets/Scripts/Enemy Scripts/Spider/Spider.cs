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
    //public float distance;

    private void Awake()
    {
        speed = -4f;
        facing_right = true;
        animator.SetFloat("speed", 1);
        //m_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(detect_ground.position, Vector2.down, LayerMask.GetMask("jumpableGround"));
        if(groundInfo.collider == false)
        {
            if(facing_right)
            {
                //m_sprite.flipX = true;
                transform.eulerAngles = new Vector3(0,-180,0);
                facing_right = false;
                //speed = -speed;
            }
            else
            {
                //m_sprite.flipX = false;
                transform.eulerAngles = new Vector3(0,0,0);
                facing_right = true;
                //speed = -speed;
            }
            //animator.SetBool("isDetected", true);
            //animator.SetFloat("speed", 1);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // void FixedUpdate()
    // {
    //     transform.Translate(Vector2.right * speed * Time.deltaTime);
    // }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        // if player touches spider, player falls down and reset scene
        /*
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            TakeDamage(50);
            CallResetScene();
        }
        */
    }

}
