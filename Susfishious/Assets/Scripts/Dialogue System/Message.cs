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
    private string CurrentText;
    [SerializeField]
    private RectTransform box;


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
    }

    public void SetText(string text)
    {
        CurrentText = text;
    }

    // Update is called once per frame
    void Update()
    {
        revealTimer += Time.deltaTime;

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
    }

    private void RevealCharacter()
    {
        if (FinishedRevealing)
        {
            return;
        }

        content.text = CurrentText.Substring(0, ++visibleCharacters);
        box.sizeDelta = new Vector2(box.sizeDelta.x, CurrentText.Length);
        if (content.text[content.text.Length - 1] != ' ')
        {
            //soundEffects.pitch = 0.3f + Random.Range(0.95f, 1.05f);
            //soundEffects.PlayOneShot(speak);
        }
    }
}
