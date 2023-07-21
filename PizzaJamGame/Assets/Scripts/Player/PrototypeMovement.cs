using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeMovement : MonoBehaviour
{
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
        
    }
}
