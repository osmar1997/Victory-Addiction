using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public AudioSource itemSound;

    void Pickup()
    {
        if (CharacterStats.Instance.currentMoney >= item.money)
        {
            CharacterStats.Instance.currentMoney -= item.money;
            InventoryManager1.Instance.Add(item);
            itemSound.Play();
            Destroy(gameObject);
        } 
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
