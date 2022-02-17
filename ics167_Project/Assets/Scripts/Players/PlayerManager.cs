using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// A script for managing the players.
/// Currently, all it does is keep track of the number of players alive, and raise
/// an OnEveryoneDied event when there are no players left.
/// </summary>

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int playerCount = 2;
    [SerializeField] private GameEvent OnEveryoneDied;

    private bool everyoneAlreadyDied;

    private void Update()
    {
        if (playerCount <= 0 && !everyoneAlreadyDied)
        {
            Debug.Log("everyone died!");
            everyoneAlreadyDied = true;
            OnEveryoneDied.Raise();
        }
    }

    public void DecrementPlayerCount()
    {
        playerCount--;
    }
}
