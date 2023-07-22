using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    #region Singleton
    private static Attacking _instance;
    public static Attacking Istance
    {
        get
        {
            if(_instance == null)
            {
                GameObject AMO = new GameObject("GameManager");
                AMO.AddComponent<Attacking>();
            }
            return _instance;
        }
        
    }
    void Awake()
    {
        _instance = this;
    }
    #endregion
    
    public bool isAttacking;
    
    private float _Damage;
    
    
    // Start is called before the first frame update
    
    public void AttackMelee(float AttackRotationAngle, GameObject Weapon)
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Do attack animation
            Weapon.transform.eulerAngles += new Vector3(0 ,0, AttackRotationAngle);
            isAttacking = true;

        }
        if(Input.GetMouseButtonUp(0))
        {
            Weapon.transform.eulerAngles -= new Vector3(0 ,0, AttackRotationAngle);
            isAttacking = false;
        }
    }
    public void AttackRanged()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Do attack animation
            //Do ranged attack
            isAttacking = true;

        }
        if(Input.GetMouseButtonUp(0))
        {
            
            isAttacking = false;
        }
    }

    
}
