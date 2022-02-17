using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// by Mindy Jun
// Resets scene when user presses "R" and pulls up menu when user presses esc.
public class AdditionalInputs : MonoBehaviour
{
    [Header("Restart and Menu Settings")]
    [SerializeField] private float levelRestartDelay;
    public GameObject optionsMenu;
    public GameObject dimImage;


    void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            ResetScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
            dimImage.gameObject.SetActive(!dimImage.gameObject.activeSelf);
        }
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
}
