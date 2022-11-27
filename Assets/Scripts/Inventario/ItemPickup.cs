using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        if (CharacterStats.Instance.currentMoney >= item.money)
        {
            CharacterStats.Instance.currentMoney -= item.money;
            InventoryManager1.Instance.Add(item);
            Destroy(gameObject);
        } 
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
