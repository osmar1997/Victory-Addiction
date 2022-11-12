using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemReference : MonoBehaviour
{
    public Image Icon;
    public Text CountText;

    public Item1 _Item { get; private set; }

    public void SetValues(Item1 item)
    {
        _Item = item;
        Icon.sprite = item.Icon;
        UpdateCount();
    }
    public void UpdateCount()
    {
        CountText.text = "x" + _Item.Count.ToString();
    }
}
