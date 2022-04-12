using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmAudioManager : MonoBehaviour
{
    public AudioSource Trackplayer;
    private AudioSource Playplayer;
    //public AudioClip myClip;

    public bool bStart = false;
    
    // Start is called before the first frame update

    void Start()
    {
        Playplayer=GetComponent<AudioSource>();
    }

     // Update is called once per frame
    void Update()
    {
        if(bStart)
        {
                Trackplayer.Play();
                bStart = false;
        }
    }

    //public void PlaySound()
    //{
    //    Playplayer.PlayOneShot(myClip);
    //}

    public void PlaySound(AudioClip aClip)
    {
        Playplayer.PlayOneShot(aClip);
    }

    public void PlayTrack()
    {
        bStart = true;
    }

}
