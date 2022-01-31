using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : UnkillableEnemy
{
    //if particle collides with player, player dies
    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            CallResetScene();
        }
    }

    /*
    //public ParticleSystem steam_puff;
    // Start is called before the first frame update
    void Start()
    {
        //steam_puff = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
}
