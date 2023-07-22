using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string _ItemName;
    public int _ItemID;
    public int _StackNum;
    //////////////////////////////
    public ItemType Type;

    public enum ItemType {
        Healing,
        Damaging,
        Loot,
        BuldingMaterial,
        Tools
    };
}
