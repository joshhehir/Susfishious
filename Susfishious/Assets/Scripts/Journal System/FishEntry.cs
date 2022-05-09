using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishEntry : MonoBehaviour
{
    [SerializeField]
    private GameEvent fishSelected;

    private ItemData itemReference;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMP_Text name;
    public void SetItemReference(ItemData i)
    {
        itemReference = i;
        UpdateEntry();
    }

    public ItemData GetItemData()
    {
        return itemReference;
    }

    private void UpdateEntry()
    {
        image.sprite = itemReference.sprite;
        name.text = itemReference.name;
    }

    public void FishSelected()
    {
        fishSelected.Raise(gameObject);
    }
}
