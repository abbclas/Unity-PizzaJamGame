using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeMovement : MonoBehaviour
{
    //// it's definitly crude, basic and not 
    [SerializeField] private float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // I'm not putting Time.deltaTime here
        if(Input.GetKey(KeyCode.W))
        {
            //rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.forward * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            //rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.back * speed ;
        }
        if(Input.GetKey(KeyCode.A))
        {
            //rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.left * speed ;
        }
        if(Input.GetKey(KeyCode.D))
        {
            //rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.right * speed ;
        }
    }
}
