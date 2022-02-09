using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameEvent OnEveryoneDied;
    [SerializeField] private int playerCount = 2;

    private void Update()
    {
        if (playerCount <= 0)
        {
            Debug.Log("everyone died!");
            OnEveryoneDied.Raise();
        }
    }

    public void DecrementPlayerCount()
    {
        playerCount--;
    }
}
