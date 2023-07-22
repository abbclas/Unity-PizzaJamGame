using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyRobotsManager : MonoBehaviour
{
    
    [SerializeField]private EnemySO enemySO;
    public float HP;
    void Awake()
    {
        HP = enemySO.MaxHP;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
