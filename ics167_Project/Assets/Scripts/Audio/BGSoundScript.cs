using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// by Mindy Jun
public class BGSoundScript : MonoBehaviour
{
    private static BGSoundScript instance;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    public AudioSource BGM;


    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Update() 
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialLevel")
        {
            Destroy(gameObject);
        }
    }

    public void Stop() 
    {
        BGM.Stop();
    }

    public void ChangeBGM(AudioClip music) 
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

}