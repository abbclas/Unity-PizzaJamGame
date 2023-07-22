using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueRobotsManager : MonoBehaviour
{
    
    [SerializeField]private EnemySO enemySO;
    public float HP;
    void Awake()
    {
        HP = enemySO.MaxHP;
    }
    
    public void TakeDamage(float _damageAmount)
    {
        HP -= _damageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}