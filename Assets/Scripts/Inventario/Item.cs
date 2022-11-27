using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Item/Create New Item")]
public class Item : ScriptableObject{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public int money;
    public int lifeTime;
    //Item type//Attack 1, defense 0
    public int type;
    public static Item Instance;
}
