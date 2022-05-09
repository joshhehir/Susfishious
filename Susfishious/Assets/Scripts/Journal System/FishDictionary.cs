using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FishDictionary : MonoBehaviour
{
    [SerializeField]
    private GameObject fishlist;
    [SerializeField]
    private GameObject fishEntryPrefab;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMP_Text nameField;
    [SerializeField]
    private TMP_Text descriptionField;
    [SerializeField]
    private TMP_Text mutationField;

    private void OnEnable()
    {
        foreach (ItemData i in Resources.LoadAll<ItemData>("Items"))
        {
            CreateFishEntry(i);
        }
        SelectFish(fishlist.transform.GetComponentsInChildren<FishEntry>()[0].gameObject);
    }

    private void CreateFishEntry(ItemData i)
    {
        FishEntry entry = Instantiate(fishEntryPrefab, fishlist.transform).GetComponent<FishEntry>();
        entry.SetItemReference(i);
    }

    public void SelectFish(GameObject g)
    {
        ItemData d = g.GetComponent<FishEntry>().GetItemData();
        icon.sprite = d.sprite;
        nameField.text = d.name;
        descriptionField.text = d.description;
        mutationField.text = d.itemMutation;
    }
}
