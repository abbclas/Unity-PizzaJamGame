using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWeapon : MonoBehaviour
{

    public bool isInHand;
    [SerializeField] private Vector3 rotationangle;
    
    private Transform player;
    public GameObject weapon;
    private GameObject weaponInst;
    public bool IsInHand;
    
    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.parent.GetComponent<Slot>().itemDropped += DropOutOfHand;
        
    }
    public void setInHand()
    {
        if(player.childCount < 1)
        {
            Debug.Log("Please remember to set number of children that the player can have");
            weaponInst = Instantiate(weapon, player.transform.position, Quaternion.identity);
            weaponInst.transform.SetParent(player);
            
        }
        

    }
    void DropOutOfHand()
    {
        Debug.Log("droppedhand");
        Destroy(weaponInst);
    }
    private void Update()
    {

    }
}
