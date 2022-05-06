using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDictionary : MonoBehaviour
{
    [SerializeField]
    private GameObject fishlist;
    [SerializeField]
    private GameObject fishEntryPrefab;

    private void OnEnable()
    {
        foreach (ItemData i in Resources.LoadAll<ItemData>("Items"))
        {
            CreateFishEntry(i);
        }
    }

    private void CreateFishEntry(ItemData i)
    {
        FishEntry entry = Instantiate(fishEntryPrefab, fishlist.transform).GetComponent<FishEntry>();
        entry.SetItemReference(i);
    }
}
