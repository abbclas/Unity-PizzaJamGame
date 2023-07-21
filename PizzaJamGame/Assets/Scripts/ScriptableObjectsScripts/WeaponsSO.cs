using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponsSO", menuName = "ItemsSO/WeaponsSO")]
public class WeaponsSO : ScriptableObject
{
    public string _WeaponName;
    public float _Damage;
    public float _MaxDamage;
    public int _StackNum;
    
    public WeaponType Type;

    public enum WeaponType {
        Ranged,
        Melee
    };
    
}
