using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Transform firstPos;
    private Transform secondPos;
    private bool firstIsFull;

    // Start is called before the first frame update
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
