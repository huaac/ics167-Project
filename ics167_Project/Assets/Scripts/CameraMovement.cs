using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Aissa Akiyama
// This is a simple temporary script for a camera that follows the player.
// TODO: stop following player when player dies

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player1;

    void Update()
    {
        transform.position = new Vector3(player1.position.x, player1.position.y, -10);
    }
}
