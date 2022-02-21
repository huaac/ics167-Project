using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// This script allows the detection of an enemy when attached to a GameObject.
/// Best used with hitboxes.
/// </summary>

public class EnemyDetector : MonoBehaviour
{
    private GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") && (enemy == null))
        {
            Debug.Log("Detected!");
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = null;
        }
    }

    public GameObject EnteredEnemy
    {
        get { return enemy; }
    }
}
