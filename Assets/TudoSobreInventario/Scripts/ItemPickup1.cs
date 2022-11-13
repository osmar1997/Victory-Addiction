using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup1 : MonoBehaviour
{
    public Item1 Item;
    public ItemReference _element;
    void Pickup()
    {
        InventoryManager.Instance.AddItem(Item);  
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
