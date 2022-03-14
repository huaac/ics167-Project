using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// A script for moving the Helper's enemy search range.
/// The search range's position is based on which player is the "lead", i.e. which has a
/// greater x position.
/// </summary>

public class SearchRangeMovement : MonoBehaviour
{
    //[SerializeField] private Transform player1;
    //[SerializeField] private Transform player2;
    private Transform player1;
    private Transform player2;

    private void Update()
    {
        // This is performance-wise very bad.
        // Unfortunately this has to be done for networking, since you don't know when
        // players will be instantiated into the scene.
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            player1 = players[0].transform;
            transform.position = player1.position;
        }
        if (players.Length > 1)
        {
            player2 = players[1].transform;
            transform.position = player1.position.x >= player2.position.x ? player1.position : player2.position;
        }
    }
}
