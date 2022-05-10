using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    public ScoreManager myScore;
    public GameObject gStart;
    public TrackScroller myTrack;
    public RhythmAudioManager myAudio;
    public GameObject RhythmGame;
    public Image ProgressMeterImage;

    private GameObject[] myNotes;

    private InputAction start;

    //float fTime = 0;
    bool bStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        myNotes = GameObject.FindGameObjectsWithTag("Note");
        start = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["Interact"];
        ProgressMeterImage = GameObject.FindGameObjectWithTag("ProgressMeter").GetComponent<Image>();
    }

    void Awake()
    {
        gStart.SetActive(true);
        
    }

    private void OnEnable()
    {
        if(myTrack != null)
        {
            myTrack.ResetTrack();
            if (myNotes != null)
            {
                foreach (var note in myNotes)
                {
                    note.SetActive(true);
                }
            }
        }

    }

    private void OnDisable()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        //if(start.triggered)
        //{
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

            ProgressMeterImage.fillAmount = 1 - myTrack.getProgress();

            if (myTrack.getStatus() == true)
            {
                RhythmGame.SetActive(false);
            }
        //}
        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        //}
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}
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

    public void ResetScore()
    {
        myScore.ResetScore();
    }

    public void PlayAudio(AudioClip aClip)
    {
        myAudio.PlaySound(aClip);
    }
}
