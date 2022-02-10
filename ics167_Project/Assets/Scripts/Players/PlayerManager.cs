using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameEvent OnEveryoneDied;
    [SerializeField] private int playerCount = 2;

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
