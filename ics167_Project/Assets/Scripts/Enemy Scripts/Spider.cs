using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : KillableEnemy
{
    //Animator myAnimator;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        // if player touches spider, player falls down
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            TakeDamage(50);
            CallResetScene();
        }
        /*
        if(col.gameObject.tag == "Player")
        {
            myAnimator = GetComponent<Animator>();
            myAnimator.SetTrigger("Touched");
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }*/
    }

}
