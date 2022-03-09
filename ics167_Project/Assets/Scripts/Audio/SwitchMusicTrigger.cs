using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;

    private BGSoundScript AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<BGSoundScript>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") 
        {
            if(newTrack != null)
                AM.ChangeBGM(newTrack);
        }
    }
}
