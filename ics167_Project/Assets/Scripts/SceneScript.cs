using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//written by Mindy Jun

public class SceneScript : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.isDead = false;
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
