using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenu : MonoBehaviour
{
    public ItemReference _element;
    private List<Item> _inventory;
    void Start()
    {
        _inventory = new List<Item>();
        _inventory= FindObjectOfType<FakeInventory>()._Inventory;
        InstatntieteElements();
    }

    private void InstatntieteElements()
    {
        for(int i =0;i<_inventory.Count;i++)
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
