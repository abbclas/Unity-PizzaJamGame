using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;
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
    
    public void AttackMelee(float AttackRotationAngle, GameObject Weapon, GameObject player, Camera camera)
    {
        
        Vector3 MousePoS = MousePos.Instance.mousePOS;
        
        

        if(Input.GetMouseButtonDown(0))
        {
            player.transform.LookAt(MousePoS);
            Weapon.transform.localEulerAngles += new Vector3(0, AttackRotationAngle, 0);
            Weapon.transform.localEulerAngles -= new Vector3(0,  2 * AttackRotationAngle, 0);
            isAttacking = true;

        }
        if(Input.GetMouseButtonUp(0))
        {
            
            Weapon.transform.localEulerAngles += new Vector3(0, AttackRotationAngle, 0);
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
