using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool isFP;
    private Inventory inventory;
    [SerializeField] private GameObject objButton;
    [SerializeField] private GameObject objButInst;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        objButInst = Instantiate(objButton); 
        objButInst.SetActive(false);
        PlayerManager.isFPressed += isfPressed;
    }
    private void isfPressed(bool isfp)
    {
        isFP = isfp;
        Debug.Log("isFP");
    }
    void OnTriggerStay(Collider other)
    {
            Debug.Log(other.transform.tag);
            if(other.CompareTag("Player")  && isFP)
            {
                
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        objButInst.transform.position = inventory.slots[i].transform.position;
                        objButInst.SetActive(true);
                        objButInst.transform.SetParent(inventory.slots[i].transform);
                        
                        Debug.Log("inst");
                        inventory.isFull[i] = true;
                        Destroy(this.gameObject);
                        
                        break;
                    }
                }
            }
    }
}
