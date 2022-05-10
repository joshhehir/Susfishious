using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    public float fTrackOriginalTimer = 85f;
    public float fTime = 0f;
    public float fTrackSpeed = 3f;              // track multiplier
    public bool bStart = false;             // Bool Rhythm game start check
    private bool bStop = false;


    // Start is called before the first frame update
    void Start()
    {
        fTime = fTrackOriginalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (bStart == true)
        {
            this.transform.Translate(-fTrackSpeed * Time.deltaTime, 0, 0);
        }

        if (fTime > 0)
        {
            fTime -= Time.deltaTime;
        }
        
        else if(fTime <= 0)
        {
            bStop = true;
        }
    }

    public bool getStatus()
    {
        return bStop;
    }

    public float getProgress()
    {
        return fTime / fTrackOriginalTimer;
    }

    public float getOriginalTime()
    {
        return fTrackOriginalTimer;
    }
    public void ResetTrack()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
        fTime = fTrackOriginalTimer;
        bStop = false;
    }
    public void Activate()
    {
        bStart = true;
    }
}
