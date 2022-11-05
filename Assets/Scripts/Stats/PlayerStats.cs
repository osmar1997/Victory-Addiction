//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerStats : CharacterStats
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
//    }

//    void OnEquipmentChanged(Equipment newItem, Equipment oltItem)
//    {
//        if (newItem != null) 
//        { 
//        armor.AddModifier(newItem.armorModifier);
//        damage.AddModifier(newItem.damageModifier);
//        }
//        if (oltItem != null)
//        {
//            armor.RemoveModifier(oldItem.armorModifier);
//            damage.RemoveModifier(oldItem.damageModifier);
//        }
//    }
//}
