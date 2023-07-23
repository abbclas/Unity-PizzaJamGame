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
    
    #region Variables
        
        
        private float _Damage;
        
        private WeaponsSO thisweaponSO;
        private GameObject weapon;
        private float ra;
    #endregion
////////////////////////
    #region AttacksPublic
        public void MeleeAttack(float _AttackRotationAngle, GameObject _Weapon, GameObject _player, Camera _camera)
        {
            if(PlayerManager.Istance.playerState == PlayerManager.State.AttackingFinish
            || PlayerManager.Istance.playerState == PlayerManager.State.AttackingStart 
            || PlayerManager.Istance.playerState == PlayerManager.State.Idle 
            || PlayerManager.Istance.playerState == PlayerManager.State.Moving)
            {
                AttackMelee( _AttackRotationAngle,  _Weapon,  _player,  _camera);
                
            }
            
    
        }
        public void RangedAttack(float _AttackRotationAngle, GameObject _Weapon, GameObject _player, Camera _camera)
        {
            if(PlayerManager.Istance.playerState == PlayerManager.State.AttackingFinish
            || PlayerManager.Istance.playerState == PlayerManager.State.AttackingStart
            || PlayerManager.Istance.playerState == PlayerManager.State.Idle 
            || PlayerManager.Istance.playerState == PlayerManager.State.Moving)
            {
                AttackRanged( _AttackRotationAngle,  _Weapon,  _player,  _camera);
            }
            
    
        }
    #endregion
    #region AttackPrivate
        IEnumerator IAttacking()
        {
            PlayerManager.Istance.playerState = PlayerManager.State.AttackingStart;
            weapon.transform.localEulerAngles += new Vector3(0, ra, 0);
            yield return new WaitForSeconds(0.1f);
            weapon.transform.localEulerAngles -= new Vector3(0,  2 * ra, 0);
            yield return new WaitForSeconds(0.1f);
            weapon.transform.localEulerAngles += new Vector3(0, ra, 0);
            yield return new WaitForSeconds(0.1f);
            PlayerManager.Istance.playerState = PlayerManager.State.AttackingFinish;
            
            
        }
        private void AttackMelee(float AttackRotationAngle, GameObject Weapon, GameObject player, Camera camera)
        {
            weapon = Weapon;
            ra = AttackRotationAngle;
            
            Vector3 MousePoS = MousePos.Instance.mousePOS;
            
            
    
            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(IAttacking());
                player.transform.LookAt(MousePoS);
                
                
    
            }
            if(Input.GetMouseButtonUp(0))
            {
                
                
                PlayerManager.Istance.playerState = PlayerManager.State.AttackingFinish;
            }
        }
        private void AttackRanged(float AttackRotationAngle, GameObject Weapon, GameObject player, Camera camera)
        {
            if(Input.GetMouseButtonDown(0))
            {
                //Do attack animation
                //Do ranged attack
                PlayerManager.Istance.playerState = PlayerManager.State.AttackingStart;
    
            }
            if(Input.GetMouseButtonUp(0))
            {
                PlayerManager.Istance.playerState = PlayerManager.State.AttackingFinish;
            }
        }
    #endregion

    
}
