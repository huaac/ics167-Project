using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// spiders can be killed in the future
// will have more functions in future playtest

public class Spider : KillableEnemy
{
    //Animator myAnimator; (will be animated in the future)

    public override void OnCollisionEnter2D(Collision2D col)
    {
        // if player touches spider, player falls down and reset scene
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            TakeDamage(50);
            CallResetScene();
        }
    }

}
