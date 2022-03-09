using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama
// A script just to hold information about which wait position at the goal is/is not full yet.

public class Finish : MonoBehaviour
{
    private Transform firstPos;
    private Transform secondPos;
    private bool firstIsFull;

    private void Awake()
    {
        firstPos = transform.GetChild(0);
        secondPos = transform.GetChild(1);
        firstIsFull = false;
    }

    public Transform EmptyPosition()
    {
        if (!firstIsFull)
        {
            firstIsFull = true;
            Debug.Log(firstPos.position);
            return firstPos;
        }
        else
        {
            Debug.Log(secondPos.position);
            return secondPos;
        }
    }
}
