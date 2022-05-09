using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField]
    private TMP_Text content;
    [SerializeField]
    public string CurrentText;
    //This is the panel within the message object
    [SerializeField]
    private RectTransform box;
    //This is the message object itself
    private RectTransform heightBox;
    [SerializeField]
    private bool skipTypeEffect;


    public bool FinishedRevealing => visibleCharacters >= CurrentText.Length;

    [SerializeField]
    private AudioClip speak;

    private float revealSpeed = 14; // characters per second
    private int visibleCharacters = 0;
    private float revealTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        content.font = Resources.Load<GlobalSettings>("GlobalSettings").font;


        visibleCharacters = 0;
        revealTimer = 0;

        visibleCharacters = 0;

        heightBox = GetComponent<RectTransform>();
    }

    public void SetText(string text, bool skipTyping)
    {
        skipTypeEffect = skipTyping;
        CurrentText = text;
    }

    // Update is called once per frame
    void Update()
    {
        revealTimer += Time.deltaTime;
        if (skipTypeEffect && !FinishedRevealing)
        {
            RevealAll();
        }
        if (revealTimer > (1 / revealSpeed))
        {
            RevealCharacter();
            revealTimer = 0;
        }
    }

    public void RevealAll()
    {
        visibleCharacters = CurrentText.Length;
        content.text = CurrentText;
        SetSize();
    }

    private void RevealCharacter()
    {
        if (FinishedRevealing)
        {
            return;
        }

        content.text = CurrentText.Substring(0, ++visibleCharacters);
        SetSize();
        if (content.text[content.text.Length - 1] != ' ')
        {
            //soundEffects.pitch = 0.3f + Random.Range(0.95f, 1.05f);
            //soundEffects.PlayOneShot(speak);
        }
    }

    //For formatting reasons, the message object has to be changed in height instead of the panel, to ensure that messages know how to layout in relation to one another correctly
    private void SetSize()
    {
        var sizeX = Mathf.Min(20 + visibleCharacters * 8, 300);
        var sizeY = 50 + Mathf.CeilToInt((20 + visibleCharacters * 8) / 300) * 20;
        Debug.Log(sizeX + " : " + sizeY);
        box.sizeDelta = new Vector2(sizeX, box.sizeDelta.y);
        heightBox.sizeDelta = new Vector2(heightBox.sizeDelta.x, sizeY);
    }
}
