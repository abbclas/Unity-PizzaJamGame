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
    
    #region DamageAndLivingStatus
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
    #endregion
    #region DamageEnemy
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerManager.Istance.RecieveDamage(enemySO.DamageDealAmount);
        }
    }
    #endregion
    void Update()
    {
        CalcHP();
    }
}
