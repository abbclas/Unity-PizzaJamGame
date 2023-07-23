using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : Attacking
{

    [SerializeField] private WeaponsSO BladeSO;
    [SerializeField] private float rotationAngle;
    [SerializeField] private bool isInHand;
    private void OnTriggerStay(Collider other)
    {
        
        if(other.GetComponent<RogueRobotsManager>() && isAttacking)
        {
            Debug.Log("Hit" + other.transform);
            Debug.Log("Hit + damage");
            other.GetComponent<RogueRobotsManager>().TakeDamage(BladeSO._Damage);
            
        }
    }
    
    
    private void SwingBlade()
    {
        if(isInHand)
        {
            Attacking.Istance.AttackMelee(rotationAngle, this.gameObject);
        }
    }
    

    void Update()
    {
        
        SwingBlade();
    }
}
