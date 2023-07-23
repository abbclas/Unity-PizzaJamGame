using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject item;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void DropItem()
    {
        if(this.gameObject.transform.parent != null)
        {
            Instantiate(item, player.transform.position + (new Vector3(5,0,5)), Quaternion.identity);
        }
        
    }
}
