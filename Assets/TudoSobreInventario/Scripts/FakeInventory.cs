using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FakeInventory : MonoBehaviour
{
    [SerializeField]
    Item[] arrayInventory=new Item[35];

    public List<Item> _Inventory { get; private set; }

    private void Awake()
    {
        _Inventory = new List<Item>();
        _Inventory = arrayInventory.OrderBy(i => i.Name).ToList();
        MouseSensitive.IsClicked += RemoveItem;
    }
    private void OnDestroy()
    {
        MouseSensitive.IsClicked -= RemoveItem;
    }
    public void AddItem(Item item)
    {
        if (item != null)
        { 
            _Inventory.Add(item);
        }
    }
    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            _Inventory.Remove(item);
        }
    }

}
