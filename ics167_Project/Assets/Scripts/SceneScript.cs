using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() 
    {
        Debug.Log("QUTI!");
        Application.Quit();
    }

    public void GoToMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
