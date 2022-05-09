using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentTabHeader : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tabTitle;

    public void SetTab(Tab t)
    {
        if (tabTitle.text != t.Name)
        {
            tabTitle.text = t.Name;

            int tabIndex = t.transform.GetSiblingIndex();
            int titleIndex = tabTitle.transform.GetSiblingIndex();
            if (tabIndex < titleIndex) tabIndex += 1;

            tabTitle.transform.SetSiblingIndex(tabIndex);
        }
    }
}
