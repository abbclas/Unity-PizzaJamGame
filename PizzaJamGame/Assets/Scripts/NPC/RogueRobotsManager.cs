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
            Debug.Log("exit");
            StopCoroutine(IAttacker());
            
        }
    }
    #endregion
    void Update()
    {
        CalcHP();
    }
}
