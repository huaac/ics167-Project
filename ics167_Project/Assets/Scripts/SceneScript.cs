using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//written by Mindy Jun
// level restart added by Aissa Akiyama

public class SceneScript : MonoBehaviour
{
    [SerializeField] private float levelRestartDelay;

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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
