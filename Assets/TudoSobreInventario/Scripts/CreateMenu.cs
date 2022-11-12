using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenu : MonoBehaviour
{
    public static CreateMenu Instance;
    public ItemReference _element;
    public List<Item1> _inventory;
    void Start()
    {
        Instance = this;
        _inventory = InventoryManager.Instance._Inventory;
        _inventory= FindObjectOfType<InventoryManager>()._Inventory;
        InstantieteElements();
    }

    public void InstantieteElements()
    {
        
        for (int i =0;i<_inventory.Count;i++)
        {
            if (isRepeated(i)) { continue; }
            (Instantiate(_element, transform) as ItemReference).SetValues(_inventory[i]);
        }
    }
    bool isRepeated(int i)
    {
        if(i==0) { return false; }
        return _inventory[i].ID == _inventory[i - 1].ID;
    }
}
