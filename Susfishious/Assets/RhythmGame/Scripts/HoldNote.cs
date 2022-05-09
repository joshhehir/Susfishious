using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HoldNote : Note
{
    public BoxCollider2D NoteEnd;
    public Image[] NoteRenders;

    // Start is called before the first frame update
    void Start()
    {
        NoteRenders = GetComponentsInChildren<Image>();
        myManager = Manager.GetComponent<RhythmManager>();
        ActionA = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["ActionA"];
        ActionB = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["ActionB"];
        NoteCenter = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        if (bPressable == true && ActionA.IsPressed() && myKey == KeyCode.Z)
        {
            //if (bPressable == true && bPressed == false)
            //{
                myText.SetActive(false);
                if (ftimer > 0.25)
                {
                    myManager.AddScore(30);
                    myManager.DisplayFloatScore(300);
                    myManager.PlayAudio(myDrumAudioClip);
                    ftimer = 0;
                }



                bPressed = true;
            //}
        }
        else if (bPressable == true && ActionB.IsPressed() && myKey == KeyCode.X)
        {
            //if ( && bPressed == false)
            //{
                myText.SetActive(false);
                if (ftimer > 0.25)
                {
                    myManager.PlayAudio(myDrumAudioClip);
                    myManager.AddScore(30);
                    myManager.DisplayFloatScore(300);
                    ftimer = 0;
                }
                


                
                bPressed = true;
            //}
        }

        if(ftimer <= 1.1)
        {
            ftimer += Time.deltaTime;
        }
    }

    //Scrolls this Note object
    private void Scroll()
    {
        if (bStart == true)
        {
            this.transform.Translate(-fTempo * Time.deltaTime, 0, 0);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
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

        if (NoteEnd.IsTouching(other) && other.tag == "Killzone")
        {
            bStart = false;
            foreach(Image Renders in NoteRenders)
            {
                Renders.enabled = false;
            }
            myText.SetActive(false);

            if (!bPressed)
            {
                myManager.DisplayFloatScore(0);
                myManager.ResetCombo();
            }


            //TODO add a pop up cross out mark
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Crosshair")
        {
            if (NoteCenter.IsTouching(other) == false)
            {
                bPressable = false;
            }
        }
    }
}
