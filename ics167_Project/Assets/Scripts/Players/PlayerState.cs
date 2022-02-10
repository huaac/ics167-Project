using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// This is a class that keeps track of the player's state. Right now this is just for if a player
/// has collected a power-up or not.
/// Other classes can use this class by checking if an object has a PlayerState component and
/// checking if the HasXXX power-up is true/false.
/// </summary>

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int playerID;

    private bool isDead;
    private bool isUsingPowerUp;

    // bool's to enable/disable power ups
    private bool doubleJumpEnabled;
    //private bool speedEnabled;
    private bool wallJumpEnabled;
    private bool proteinEnabled;
    private bool chewEnabled;

    private float speedMultiplier;


    public int PlayerID
    {
        get { return playerID; }
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    public bool IsUsingPowerUp
    {
        get { return isUsingPowerUp; }
        set { isUsingPowerUp = value; }
    }


    public bool HasDoubleJump
    {
        get { return doubleJumpEnabled; }
        set { doubleJumpEnabled = value; }
    }

    /*
    public bool HasSpeed
    {
        get { return speedEnabled; }
        set { speedEnabled = value; }
    }
    */

    public float SpeedMultiplier
    {
        get { return speedMultiplier; }
        set { speedMultiplier = value; }
    }

    public bool HasWallJump
    {
        get { return wallJumpEnabled; }
        set { wallJumpEnabled = value; }
    }

    public bool HasProtein
    {
        get { return proteinEnabled; }
        set { proteinEnabled = value; }
    }

    public bool HasChew
    {
        get { return chewEnabled; }
        set { chewEnabled = value; }
    }
}
