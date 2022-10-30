
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */
public class InventoryUI : MonoBehaviour { 
    Inventario inventario;
    public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;   // The parent object of all the items

    void Start()
    {
        inventario=Inventario.instance;
        inventario.onItemChangedCallback +=UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventario"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        InventarioSlot[] slots = GetComponentsInChildren<InventarioSlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventario.items.Count)
            {
                slots[i].AddItem(inventario.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
