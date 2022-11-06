using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager Instance;
    
    public List<Item> _Inventory= new List<Item>();
    
    private void Awake()
    {
        Instance = this;
        _Inventory = _Inventory.OrderBy(i => i.Name).ToList();
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
