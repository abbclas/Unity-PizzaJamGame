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
    
    private void TakeDamage(float _damageAmount)
    {
        this.HP -= _damageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
