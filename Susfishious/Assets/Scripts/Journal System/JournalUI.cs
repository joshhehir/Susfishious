using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JournalUI : MonoBehaviour
{
    [SerializeField]
    private List<Tab> tabs;
    [SerializeField]
    private List<GameObject> menus;
    [SerializeField]
    private CurrentTabHeader header;

    private InputAction close;

    // Start is called before the first frame update
    void OnEnable()
    {
        SelectTab(tabs[0].gameObject);
        close = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["CloseJournal"];
    }

    // Update is called once per frame
    void Update()
    {
        if (close.triggered)
        {
            gameObject.SetActive(false);
        }
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

    public void LoadTab(int index)
    {
        SelectTab(tabs[index].gameObject);
    }
}
