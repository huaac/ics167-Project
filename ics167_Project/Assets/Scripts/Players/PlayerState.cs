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

    private float speedMultiplier = 1f;


    public int PlayerID
    {
        get { return playerID; }
    }

    public bool IsDead
    {
        get { return isDead; }
    }
    public void SetToDead()
    {
        isDead = true;
    }

    public bool IsUsingPowerUp
    {
        get { return isUsingPowerUp; }
    }
    public void SetToPowerUp()
    {
        isUsingPowerUp = true;
    }
    public void SetToNoPowerUp()
    {
        isUsingPowerUp = false;
    }


    public bool HasDoubleJump
    {
        get { return doubleJumpEnabled; }
    }
    public void EnableDoubleJump()
    {
        doubleJumpEnabled = true;
    }
    public void DisableDoubleJump()
    {
        doubleJumpEnabled = false;
    }

    public float SpeedMultiplier
    {
        get { return speedMultiplier; }
    }
    public void EnableSpeed(float speed)
    {
        speedMultiplier = speed;
    }
    public void DisableSpeed()
    {
        speedMultiplier = 1f;
    }

    public bool HasWallJump
    {
        get { return wallJumpEnabled; }
    }
    public void EnableWallJump()
    {
        wallJumpEnabled = true;
    }
    public void DisableWallJump()
    {
        wallJumpEnabled = false;
    }

    public bool HasProtein
    {
        get { return proteinEnabled; }
    }
    public void EnableProtein()
    {
        proteinEnabled = true;
    }
    public void DisableProtein()
    {
        proteinEnabled = false;
    }

    public bool HasChew
    {
        get { return chewEnabled; }
    }
    public void EnableChew()
    {
        chewEnabled = true;
    }
    public void DisableChew()
    {
        chewEnabled = false;
    }
}
