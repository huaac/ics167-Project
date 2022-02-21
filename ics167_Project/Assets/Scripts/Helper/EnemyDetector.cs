using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    //[SerializeField] private Transform searcher;
    private GameObject enemy;

    private void Update()
    {
        //gameObject.transform.position = searcher.transform.position;
    }

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
