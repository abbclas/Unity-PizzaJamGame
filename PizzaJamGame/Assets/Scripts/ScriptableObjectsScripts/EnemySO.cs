using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemySO", menuName = "ItemsSO/EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private float HP;
    [SerializeField] private float MaxHP;
}
