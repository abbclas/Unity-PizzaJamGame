using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : MonoBehaviour
{
    

    
    
    [SerializeField] private WeaponsSO BladeSO;
    [SerializeField] private float? SwingSpeed;
    [SerializeField] private float rotationAngle;
    [SerializeField] private bool isAttacking;
    private void Start()
    {
        
    }
    
    private void OnTriggerCollider(Collider other)
    {
        if(other.GetComponent<RogueRobotsManager>() && isAttacking)
        {
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
