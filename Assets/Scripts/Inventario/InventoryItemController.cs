using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    public Button RemoveButton;

    public void RemoveItem()
    {
        Debug.Log(item.type);
        if (item.type == 0)
        {
            Debug.Log(item.value);
            CharacterStats.Instance.currentArmorDefense = item.value;
            Debug.Log(CharacterStats.Instance.currentArmorDefense);
        }
        InventoryManager1.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
