using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTrap : KillableEnemy
{
    Animator myAnimator;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            myAnimator = GetComponent<Animator>();
            myAnimator.SetTrigger("Touched");
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
