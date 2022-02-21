using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// steam puffs are enemy to player

public class Steam : UnkillableEnemy
{
    [SerializeField]
    private ParticleSystem particles;
    
    void Start()
    {
        //particles = gameObject.GetComponent<ParticleSystem>();
    }
    
    //if particle collides with player, player dies
    void OnParticleCollision(GameObject other)
    {
        
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            CallResetScene();
        }
    }

    public override void Freeze()
    {
        particles.Pause();
    }

    public override void UnFreeze()
    {
        particles.Play();
    }
}
