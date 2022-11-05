using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    void Update()
    {
        if (Input.GetButtonDown("DesativarInventario"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}
