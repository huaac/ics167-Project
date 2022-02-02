using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added in / edited by Alice Hua
// Taken from https://www.youtube.com/watch?v=11ofnLOE8pw&ab_channel=AlexanderZotov

public class Spark : UnkillableEnemy
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;  // holds index of next curve array to follow

    private float tParam;   // for curve formula

    private Vector2 objectPosition; // object / spark position

    private float speedModifier;

    private bool coroutineAllowed;  // stop running another coroutine if already have 1

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if player touches spark, player falls down
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            CallResetScene();
        }
        
    }
}
