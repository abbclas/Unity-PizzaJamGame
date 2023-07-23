using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int EnemyKilledNum;
    [SerializeField] private float sliderValueUI;
    [SerializeField] TMP_Text tmpText;
    [SerializeField] private float HP;
    [SerializeField] private float MaxHP;
    [SerializeField] private float LEVEL;
    [SerializeField] private float LevelProgressCoEf;
    [SerializeField]private Slider LVLUISlider;

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
                isFPressed(true);
            }
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            if(isFPressed != null)
            {
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
        HP = MaxHP;
        _instance = this;
        playerState = State.Idle;
        LEVEL = 0;
    }
    
    #region Existance
    [SerializeField] private Slider sliderHP;
        public void CalcHP()
        {
            if(HP <= 0)
            {

                HP = 0;
                Destroy(sliderHP.transform.Find("Fill").gameObject);
                Die();
            }
            sliderHP.value = HP/100;                
        }
        public void RecieveDamage(float _damageAmount)
        {
            HP -= _damageAmount;
        }
        private void Die()
        {
            this.gameObject.SetActive(false);
        }
        private void HandleExistance()
        {
            CalcHP();
        }
    #endregion
    
    #region LevelSystem
    public void SetLvl()
    {
        if(LEVEL == 0)
        {
            if(EnemyKilledNum > 2)
            {
                LEVEL = 1;
                EnemyKilledNum = 0;
                leveUI();
            }
        }
        else if (LEVEL > 0)
        {
            if(EnemyKilledNum >= (LEVEL * LevelProgressCoEf))
            {
                LEVEL ++;
                EnemyKilledNum = 0;
                leveUI();
                
            }
        }
    }
    public void leveUI()
    {
        
        if(LEVEL != 0)
        {
            float DivFact = LEVEL * LevelProgressCoEf;
            sliderValueUI = (EnemyKilledNum / DivFact);
            LVLUISlider.value = sliderValueUI;
            
        }
        if(LEVEL == 0)
        {
            if(EnemyKilledNum == 1)
            {
                LVLUISlider.value = 0.5f;
            }
            else if(EnemyKilledNum == 2)
            {
                LVLUISlider.value = 1;
            }
            else if(EnemyKilledNum == 0)
            {
                LVLUISlider.value = 0;
            }
            
        }
        tmpText.text = LEVEL.ToString();   
    }
    public void HandleLVL()
    {
        SetLvl();
        leveUI();
    }
    #endregion
    public void Update()
    {
        PickupItemPressed();
        HandleExistance();
        HandleLVL();
    }
}
