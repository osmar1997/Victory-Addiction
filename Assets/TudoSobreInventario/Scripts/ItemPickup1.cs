using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup1 : MonoBehaviour
{
    public Item1 Item;

    void Pickup()
    {
        
        InventoryManager.Instance.AddItem(Item);
       //CreateMenu.Instance.InstantieteElements();
        
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
