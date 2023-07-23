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
    
    #endregion
    #region PickupAndDrop
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
    #endregion
    // Update is called once per frame
    #region StateMachine
    public enum State{
        Idle,
        AttackingStart,
        AttackingFinish,
        Moving
    }
    public State playerState;
    public delegate void NewState(State _newState);
    public static event NewState StateChanged;


    #endregion
    public void Awake()
    {
        _instance = this;
        playerState = State.Idle;
    }
    
    public void CalcAttackState()
    {
        
    }
    public void Update()
    {
        PickupItemPressed();
    }
}
