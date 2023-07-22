using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponsSO", menuName = "ScriptableObjects/WeaponsSO")]
public class WeaponsSO : ScriptableObject
{
    public string _WeaponName;
    public int _WeaponID;
    public float _Damage;
    public float _MaxDamage;
    public float? _FireRate;
    public int _StackNum;
    //////////////////////////////
    public WeaponType _Type;
    
    

    public enum WeaponType {
        Ranged,
        Melee
    };
    
}
