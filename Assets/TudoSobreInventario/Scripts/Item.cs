using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Create Item")]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int value;
    public int ID { get; private set; }

 
    public int Count { get {
            return FindObjectOfType<InventoryManager>()._Inventory.FindAll(x => x.ID == this.ID).Count;
        }
    }
    private void OnEnable() => ID = this.GetInstanceID();
}
    