using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager Instance;
    
    public List<Item1> _Inventory= new List<Item1>();
    
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
    public void AddItem(Item1 item)
    {
        if (item != null)
        { 
            _Inventory.Add(item);
           
        }
    }
    public void RemoveItem(Item1 item)
    {
        if (item != null)
        {
            _Inventory.Remove(item);
        }
    }

}
