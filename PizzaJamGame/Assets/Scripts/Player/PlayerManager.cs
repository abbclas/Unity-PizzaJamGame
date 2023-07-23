using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    private static PlayerManager _instance;
    public static PlayerManager Istance
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
    // Start is called before the first frame update
    public delegate void IsFPressed(bool _isFpressed);
    
    public static event IsFPressed isFPressed;
    [SerializeField] private float HP;
    [SerializeField] private float MaxHP;
    [SerializeField] private int Level;

    void Start()
    {
        
        HP = MaxHP;
    }
    public bool isFpressed() {return true;} 
    public void PickupItemPressed()
    {
        if(Input.GetKey(KeyCode.F))
        {
            if(isFPressed != null)
            {
                Debug.Log("isfpressed");
                isFPressed(true);
            }
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            if(isFPressed != null)
            {
                Debug.Log("isfpressed");
                isFPressed(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        PickupItemPressed();
    }
}
