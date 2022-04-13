using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private GameObject gScore;
    private GameObject gCombo;

    private GameObject gScoreText;

    private TextMeshProUGUI ScoreText;
    private TextMeshProUGUI ComboText;

    private TextMeshPro FloatingScore;
    private float fTimer = 0;

    private float fScore = 0;
    private float fCombo = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(gScore == null)
        {
            gScore = GameObject.FindGameObjectWithTag("Score");
        }

        ScoreText = gScore.GetComponent<TextMeshProUGUI>();

        if (gCombo == null)
        {
            gCombo = GameObject.FindGameObjectWithTag("Combo");
        }

        ComboText = gCombo.GetComponent<TextMeshProUGUI>();


        if (gScoreText == null)
        {
            gScoreText = GameObject.FindGameObjectWithTag("ScoreFloatText");
        }

        FloatingScore = gScoreText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = fScore.ToString();
        ComboText.text = fCombo.ToString() + " " + "Combo";
        
        if(fTimer > 0)
        {
            fTimer -= Time.deltaTime;
        }
        else
        {
            FloatingScore.text = "";
        }
    }

    public void AddScore(float aScore)
    {
        fScore += aScore;
        AddCombo(1.0f);
    }

    public void AddCombo(float aCombo)
    {
        fCombo += aCombo;
    }

    public void ResetCombo()
    {
        fCombo = 0;
    }

    public void DisplayFloatingScore(float aScore)
    {
        if (aScore == 0)
        {
            FloatingScore.text = "MISS";
        }
        else
        {
            FloatingScore.text = "+" + aScore.ToString();
        }
        
        fTimer = 10;
    }
}
