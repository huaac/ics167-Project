﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;                       //added by Alice for network

// written by Mindy Jun
// level restart added by Aissa Akiyama

public class SceneScript : MonoBehaviour
{
    [SerializeField] private float levelRestartDelay;
    [SerializeField] private IntVariable restartCount;

    //Loads the first level
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    // Resets current level
    public void ResetScene()
    {
        StartCoroutine(ResetAfterDelay(levelRestartDelay));
    }

    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IncrementRestartCount();
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(scene.name);
        PhotonNetwork.LoadLevel(scene.name);        //added by alice for network
    }

    public void LoadNextLevel()
    {
        ResetRestartCount();
        GameManager.Instance.completedLevels += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
        }
    }

    //Quits the game. Only works when it's played as a game,
    //not in the Unity Client. It'll print out "QUIT!" in the log.
    public void QuitGame() 
    {
        ResetRestartCount();
        Debug.Log("QUIT!");
        PlayerPrefs.SetInt("levelsUnlocked", 1);
        Application.Quit();
    }

    //Switches to the Title Screen/Menu Screen
    public void GoToMenu() 
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    private void IncrementRestartCount()
    {
        restartCount.value += 1;
    }
    private void ResetRestartCount()
    {
        restartCount.value = 0;
    }
}
