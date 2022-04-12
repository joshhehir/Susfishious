using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private SpriteRenderer NoteRender;
    private BoxCollider2D NoteCenter;
    private CircleCollider2D NoteCircle;
    //private RhythmAudioManager myAudioSource;
    private RhythmManager myManager;


    public GameObject myText;
    public GameObject Manager;
    
    public AudioClip myDrumAudioClip;
    public KeyCode myKey;

    public float fTempo = 120;              // Float BPM
    public float fNoteDefaultSpeed = -1.0f; // Float note speed
    public bool bStart = false;             // Bool to start movement
    public bool bPressable = false;         // Bool Note pressable 
    public bool bExact = false;             // Bool Note on centre of target

    private bool bPressed = false;


    //debug 
    //public float ftimer = 0;
    
    //public bool count = false;
    
    // Start is called before the first frame update
    void Start()
    {
            
        NoteRender = GetComponentInChildren<SpriteRenderer>();
        NoteCenter = GetComponent<BoxCollider2D>();
        NoteCircle = GetComponent<CircleCollider2D>();
        //myAudioSource = Manager.GetComponent<RhythmAudioManager>();
        myManager = Manager.GetComponent<RhythmManager>();


        if (fTempo != 0)
        {
            fTempo =   fTempo / 60f;
        }
        else
        {
            fTempo = 120/60f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();

        if(Input.GetKeyDown(myKey))
        {
            if(bExact == true && bPressable == true && bPressed == false)
            {
                NoteRender.enabled = false;
                bStart = false;
                myText.SetActive(false);
                myManager.PlayAudio(myDrumAudioClip);
                myManager.AddScore(300);
                myManager.DisplayFloatScore(300);

                bPressed = true;
            }
            else if (bPressable == true && bExact == false && bPressed == false)
            {
                NoteRender.enabled = false;
                bStart = false;
                myText.SetActive(false);
                myManager.PlayAudio(myDrumAudioClip);
                myManager.AddScore(100);
                myManager.DisplayFloatScore(100);
                bPressed = true;
            }
        }

        //if (count)
        //{
        //    ftimer += Time.deltaTime;
        //}

    }

   public void Activate()
   {
       bStart = true;
       //count = true;
    }

    //Scrolls this Note object
   private void Scroll()
   {
       if (bStart == true)
       {
           this.transform.Translate(-fTempo * Time.deltaTime, 0, 0);
       }
   }

    private void OnTriggerEnter2D(Collider2D other)
    {
       //Debug.LogWarning("Detected");
       //if (other.gameObject.CompareTag("Crosshair"))
       //{
       //    bPressable = true;
       //}
        
        if (other.tag == "Crosshair")
        {
             bPressable = true;
        }
        
        if(NoteCenter.IsTouching(other))
        {
            if(other.tag == "Crosshair")
            {
                bExact = true;
                //count = false;
            }
        }
        else if (other.tag == "Killzone")
        {
            bStart = false;
            NoteRender.enabled = false;
            myText.SetActive(false);
            
            if(!bPressed)
            {
                myManager.DisplayFloatScore(0);
                myManager.ResetCombo();
            }
            

            //TODO add a pop up cross out mark
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Crosshair")
        {
            if (NoteCenter.IsTouching(other) == false)
            {
                bExact = false;
            }

            if(NoteCircle.IsTouching(other) == false)
            {
                bPressable = false;
            }
        }
    }
}
