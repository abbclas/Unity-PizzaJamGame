using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public delegate void DroppedItem();
    public event DroppedItem itemDropped;
    private Inventory inventory;
    public int i;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if(transform.childCount <= 0 )
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {
        foreach(Transform child in transform)
        {
              child.gameObject.SetActive(false);
              child.GetComponent<Spawn>().DropItem();
              itemDropped();
              Debug.Log("dropped");
              Destroy(child.gameObject, 0.5f);
        }
    }
}
