using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueRobotsManager : MonoBehaviour
{
    
    [SerializeField]private EnemySO enemySO;
    public float HP;
    [SerializeField] private float timeToAttack;
    [SerializeField] private bool isHittingPlayer;

    void Awake()
    {
        HP = enemySO.MaxHP;
        isHittingPlayer = false;
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
    IEnumerator IAttacker()
    {
        
            yield return new WaitForSeconds(timeToAttack);
            if(isHittingPlayer)
                PlayerManager.Istance.RecieveDamage(enemySO.DamageDealAmount);
            
    }
    IEnumerator IWaiter()
    {
        yield return new WaitForSeconds(timeToAttack);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            isHittingPlayer = true;
            StartCoroutine(IAttacker());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            isHittingPlayer = false;
            
        }
    }
    #endregion
    void Update()
    {
        CalcHP();
    }
}
