using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
