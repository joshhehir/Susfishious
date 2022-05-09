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
        header.SetTab(tab.GetComponent<Tab>());
        foreach (GameObject g in menus)
        {
            g.SetActive(false);
        }
        menus[tab.transform.GetSiblingIndex()].SetActive(true);
    }
}
