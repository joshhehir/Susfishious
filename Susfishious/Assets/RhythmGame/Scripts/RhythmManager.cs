using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmManager : MonoBehaviour
{
    public ScoreManager myScore;
    public GameObject gStart;
    public TrackScroller myTrack;
    public RhythmAudioManager myAudio;

    private GameObject[] myNotes;
    

    //float fTime = 0;
    bool bStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        myNotes = GameObject.FindGameObjectsWithTag("Note");
    }

    void Awake()
    {
        gStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if (!bStarted)
            {
                gStart.SetActive(false);
                myTrack.Activate();
                myAudio.PlayTrack();
                
                foreach (var note in myNotes)
                {
                    note.GetComponent<Note>().Activate();
                }
                bStarted = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void DisplayFloatScore(float aScore)
    {
        myScore.DisplayFloatingScore(aScore);
    }
    
    public void AddScore(float aScore)
    {
        myScore.AddScore(aScore);
    }

    public void ResetCombo()
    {
        myScore.ResetCombo();
    }



    public void PlayAudio(AudioClip aClip)
    {
        myAudio.PlaySound(aClip);
    }
}
