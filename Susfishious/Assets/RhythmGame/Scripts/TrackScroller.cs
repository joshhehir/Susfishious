using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    public float fTime = 30f;
    public float fTrackSpeed = 3f;              // track multiplier
    public bool bStart = false;             // Bool Rhythm game start check

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bStart == true)
        {
            this.transform.Translate(-fTrackSpeed * Time.deltaTime, 0, 0);
        }

        //if (fTime > 0)
        //{
        //    fTime -= Time.deltaTime;
        //}
        //
        //else
        //{ 
        //    bStart = false;
        //}
    }

    public void ResetTrack()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void Activate()
    {
        bStart = true;
    }
}
