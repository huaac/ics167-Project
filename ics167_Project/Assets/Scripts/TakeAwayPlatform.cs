using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Alice Hua
// simply used to take away the platform that that holds the spiders
// might take away / find a better way next playtest

public class TakeAwayPlatform : MonoBehaviour
{
    public GameObject temp_collider;

    void OnTriggerEnter2D(Collider2D col)
    {
        //if trigger catches player, then disable temp_collider
        if(col.gameObject.tag == "Player")
        {
            temp_collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
