using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Mindy Jun
// manages audio
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> soundClips = new List<AudioClip>();

    public static AudioClip biteSound, jumpSound, pickUpSound, attackSound, winSound;
    static AudioSource audioSrc;

    void Start()
    {

        jumpSound = soundClips[0];
        pickUpSound = soundClips[1];
        attackSound = soundClips[2];
        winSound = soundClips[3];

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) 
    {
        switch (clip) 
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickUpSound);
                break;
            case "attack":
                audioSrc.PlayOneShot(attackSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }
}
