using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player1;

    void Update()
    {
        transform.position = new Vector3(player1.position.x, player1.position.y, -10);
    }
}
