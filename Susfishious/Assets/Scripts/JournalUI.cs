using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    [SerializeField]
    private List<Tab> tabs;
    [SerializeField]
    private List<GameObject> menus;
    [SerializeField]
    private CurrentTabHeader header;

    // Start is called before the first frame update
    void Start()
    {
        SelectTab(tabs[0].gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTab(GameObject tab)
    {
        foreach (Tab t in tabs)
        {
            t.gameObject.SetActive(true);
        }
        tab.SetActive(false);
        header.SetTab(tab.GetComponent<Tab>());
    }
}
