using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// Rat trap can be "killed" in the future
// will add extra function in the future

public class RatTrap : KillableEnemy
{
    Animator myAnimator;

    // void FixedUpdate()
    // {
    //     // rn it only detects if mouse is straight up in the middle of the trap (FIX LATER)
    //     // not sure if I should continue using raycast or use use colliders
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up),0); //LayerMask.GetMask("Player"));

    //     if(hit.collider)
    //     {
    //         Attack();
    //     }
    // }

    public override void Attack()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("Touched");
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        // if player toucches the rat trap, rat trap animation and they fall down, then reset scene
        if(col.gameObject.tag == "Player")
        {
            Attack();
            //col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //TakeDamage(50);
            //CallResetScene();
        }
    }

}
