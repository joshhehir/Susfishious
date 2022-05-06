using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    [SerializeField]
    private GameEvent tabSelected;
    [SerializeField]
    private Image image;
    [SerializeField]
    private string name;

    public Sprite Sprite => image.sprite;
    public string Name => name;

    public void SelectTab()
    {
        tabSelected.Raise(gameObject);
    }
}
