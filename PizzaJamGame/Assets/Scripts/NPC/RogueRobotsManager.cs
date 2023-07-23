using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueRobotsManager : MonoBehaviour
{
    
    [SerializeField]private EnemySO enemySO;
    public float HP;
    [SerializeField] private float timeToAttack;
    [SerializeField] private bool isHittingPlayer;
    [SerializeField] private int enteredamount = 0;
    public bool isDead;


    void Awake()
    {
        HP = enemySO.MaxHP;
        isHittingPlayer = false;
        isDead = false;
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
                
                Dead();
            }
        }
        public void Dead()
        {
            PlayerManager.Istance.EnemyKilledNum ++;
            this.gameObject.SetActive(false);
        }
    #endregion
    #region DamageEnemy
    IEnumerator IAttacker()
    {
            
            
            enteredamount ++;
            if(enteredamount < 2)
            {
                yield return new WaitForSeconds(timeToAttack);
                PlayerManager.Istance.RecieveDamage(enemySO.DamageDealAmount);
                enteredamount --;
            }
                
            else
                enteredamount --;
            
                
            
                
            
    }
    IEnumerator IWaiter()
    {
        yield return new WaitForSeconds(timeToAttack);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            StartCoroutine(IAttacker());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopCoroutine(IAttacker());
            
        }
    }
    #endregion
    void Update()
    {
        CalcHP();
    }
}
