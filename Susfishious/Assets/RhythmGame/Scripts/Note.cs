using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Note : MonoBehaviour
{
    protected Image NoteRender;
    protected BoxCollider2D NoteCenter;
    protected RhythmManager myManager;

    protected InputAction ActionA;
    protected InputAction ActionB;

    public GameObject myText;
    public GameObject Manager;
    
    public AudioClip myDrumAudioClip;
    public KeyCode myKey;

    public float fTempo = 300;              // Float BPM
    public float fNoteDefaultSpeed = -1.0f; // Float note speed
    public bool bStart = false;             // Bool to start movement
    public bool bPressable = false;         // Bool Note pressable 
    public bool bExact = false;             // Bool Note on centre of target

    public bool bPressed = false;


    //debug 
    public float ftimer = 0;
    
    //public bool count = false;
    
    // Start is called before the first frame update
    void Start()
    {
            
        NoteRender = GetComponentInChildren<Image>();
        
        myManager = Manager.GetComponent<RhythmManager>();

        ActionA = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["ActionA"];
        ActionB = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["ActionB"];

        if (fTempo != 0)
        {
            //fTempo =   fTempo / 60f;
        }
        else
        {
            fTempo = 300/60f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Scroll();
    }

   public void Activate()
   {
       bStart = true;

    }

    //Scrolls this Note object
   private void Scroll()
   {
       if (bStart == true)
       {
           this.transform.Translate(-fTempo * Time.deltaTime, 0, 0);
       }
   }

    public virtual void OnTriggerEnter2D(Collider2D other)
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

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Crosshair")
        {
            if (NoteCenter.IsTouching(other) == false)
            {
                bExact = false;
            }
        }
    }
}
