using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// written by Alice Hua
// attempt on Factory Method as we will have more enemies
// simply for playtest 1. Will be changed in the future

public abstract class Enemy : MonoBehaviour
{
    // restarts to scene. to be used when enemy kills player
    protected void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // resets the scene when called
    protected void CallResetScene()
    {
        Invoke("ResetScene",1f);
    }
}
