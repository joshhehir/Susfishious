using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TapNote : Note
{
    private CircleCollider2D NoteCircle;

    //debug 
    //public float ftimer = 0;

    //public bool count = false;

    // Start is called before the first frame update
    void Start()
    {

        NoteRender = GetComponentInChildren<Image>();
        NoteCircle = GetComponent<CircleCollider2D>();
        NoteCenter = GetComponent<BoxCollider2D>();
        myManager = Manager.GetComponent<RhythmManager>();

        ActionA = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["ActionA"];
        ActionB = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["ActionB"];

        if (fTempo != 0)
        {
            //fTempo =   fTempo / 60f;
        }
        else
        {
            fTempo = 300 / 60f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        if (ActionA.triggered && myKey == KeyCode.Z)
        {
            if (bExact == true && bPressable == true && bPressed == false)
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
        else if (ActionB.triggered && myKey == KeyCode.X)
        {
            if (bExact == true && bPressable == true && bPressed == false)
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

        if (NoteCenter.IsTouching(other))
        {
            if (other.tag == "Crosshair")
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
                bExact = false;
            }

            if (NoteCircle.IsTouching(other) == false)
            {
                bPressable = false;
            }
        }
    }
}
