using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//written by Mindy Jun

public class SceneScript : MonoBehaviour
{
    //Loads the first level
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    //Quits the game. Only works when it's played as a game,
    //not in the Unity Client. It'll print out "QUIT!" in the log.
    public void QuitGame() 
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    //Switches to the Title Screen/Menu Screen
    public void GoToMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
