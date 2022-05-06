using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentTabHeader : MonoBehaviour
{
    [SerializeField]
    private Image tabImage;
    [SerializeField]
    private TMP_Text tabName;

    public void SetTab(Tab t)
    {
        tabImage.sprite = t.Sprite;
        tabName.text = t.Name;
    }
}
