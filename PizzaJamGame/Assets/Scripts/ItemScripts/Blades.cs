using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : Attacking
{

    [SerializeField] private WeaponsSO BladeSO;
    [SerializeField] private float rotationAngle;
    public bool Inhand;
    private GameObject player;
    public Camera MainCamera;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.localEulerAngles = new Vector3(0, 90, 0);
    }
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
        if(Inhand && !GameManager.Instance.isOnUI())
        {
            Attacking.Istance.MeleeAttack(rotationAngle, this.gameObject, player, MainCamera);
        }
    }
    

    void Update()
    {
        if(this.transform.parent != null)
        {
            if(this.transform.parent.tag == "Player")
            {
                Inhand = true;
            }
            else
            {
                Inhand = false;
            }
        }
        else
        {
            Inhand = false;
        }
        
        SwingBlade();
    }
}
