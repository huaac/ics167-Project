using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// steam puffs are enemy to player

public class Steam : UnkillableEnemy
{
    [SerializeField]
    private ParticleSystem particles;
    
    
    //if particle collides with player, player dies
    void OnParticleCollision(GameObject other)
    {
        
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            CallResetScene();
        }
    }

   // can be called by helper to stop the steam
    public override void Freeze()
    {
        particles.Pause();
    }

    // can be called by helper to retart up the steam
    public override void UnFreeze()
    {
        particles.Play();
    }
}
