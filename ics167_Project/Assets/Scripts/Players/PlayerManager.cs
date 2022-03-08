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
    [SerializeField] private int finishCount = 2;
    [SerializeField] private GameEvent OnEveryoneDied;
    [SerializeField] private GameEvent OnEveryoneFinished;

    private bool everyoneAlreadyDied;
    private bool everyoneAlreadyFinished;

    private void Update()
    {
        if (playerCount <= 0 && !everyoneAlreadyDied)
        {
            Debug.Log("everyone died!");
            everyoneAlreadyDied = true;
            OnEveryoneDied.Raise();
        }
        else if (finishCount <= 0 && !everyoneAlreadyFinished)
        {
            Debug.Log("everyone finished!");
            everyoneAlreadyFinished = true;
            OnEveryoneFinished.Raise();
        }
    }

    public void DecrementPlayerCount()
    {
        playerCount--;
    }

    public void DecrementFinishCount()
    {
        finishCount--;
    }
}
