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
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    
    private void Update()
    {
        transform.position = player1.position.x >= player2.position.x ? player1.position : player2.position;
    }
}
