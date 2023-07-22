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
    private void CalcHP()
    {
        if(HP <= 0)
        {
            HP = 0;
            enemySO.isDead = true;
            Dead();
        }
    }
    private void Dead()
    {
        if(enemySO.isDead)
        {
            
            this.gameObject.SetActive(false);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        CalcHP();
    }
}
