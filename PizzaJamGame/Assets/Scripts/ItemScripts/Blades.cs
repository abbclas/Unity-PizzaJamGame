using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : Attacking
{

    [SerializeField] private WeaponsSO BladeSO;
    [SerializeField] private float? SwingSpeed;
    [SerializeField] private float rotationAngle;
    
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Hit");
        if(other.GetComponent<RogueRobotsManager>() && isAttacking)
        {
            Debug.Log("Hit + damage");
            other.GetComponent<RogueRobotsManager>().TakeDamage(BladeSO._Damage);
        }
    }

    private void SwingBlade()
    {
        if(BladeSO._AttackSpeed != null){
            SwingSpeed = BladeSO._AttackSpeed;
        }
        if(Input.GetMouseButtonDown(0))
        {
            transform.eulerAngles += new Vector3(0 ,0, rotationAngle);
            isAttacking = true;

        }
        if(Input.GetMouseButtonUp(0))
        {
            transform.eulerAngles -= new Vector3(0 ,0, rotationAngle);
            isAttacking = false;
        }

    }
    

    void Update()
    {
        SwingBlade();
    }
}
