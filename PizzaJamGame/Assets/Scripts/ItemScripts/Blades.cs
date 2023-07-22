using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : MonoBehaviour
{
    [SerializeField] private WeaponsSO BladeSO;
    [SerializeField] private float? SwingSpeed;
    [SerializeField] private float rotationAngle;
    
    private void OnTriggerCollider(Collider other)
    {
        if(other.transform.Find(""))
        {
            DamageEnemy(other.gameObject);
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
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            transform.eulerAngles -= new Vector3(0 ,0, rotationAngle);
        }

    }
    private void DamageEnemy(GameObject Enemy)
    {
        
    }

    void Update()
    {
        SwingBlade();
    }
}
