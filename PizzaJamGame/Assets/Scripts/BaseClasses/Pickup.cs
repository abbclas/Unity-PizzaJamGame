using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private GameObject objButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Instantiate(objButton); 
        objButton.SetActive(false);
    }
   void OnTriggerStay(Collider other)
   {
        Debug.Log(other.transform.tag);
        if(other.CompareTag("Player"))
        {
            
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    objButton.transform.position = inventory.slots[i].transform.position;
                    objButton.SetActive(true);
                    objButton.transform.SetParent(inventory.slots[i].transform);
                    
                    Debug.Log("inst");
                    inventory.isFull[i] = true;
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
   }
}
