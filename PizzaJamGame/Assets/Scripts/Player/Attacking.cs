using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public WeaponsSO weaponsSO;
    public bool isAttacking;
    // Start is called before the first frame update
    private void MeleeOrRanged()
    {
        switch(weaponsSO._Type)
        {
            case WeaponsSO.WeaponType.Ranged:
                AttackRanged();
                break;
            case WeaponsSO.WeaponType.Melee:
                AttackMelee();
                break;
        }
    }
    private void AttackMelee()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            isAttacking = true;

        }
        if(Input.GetMouseButtonUp(0))
        {
            
            isAttacking = false;
        }
    }
    private void AttackRanged()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            isAttacking = true;

        }
        if(Input.GetMouseButtonUp(0))
        {
            
            isAttacking = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
