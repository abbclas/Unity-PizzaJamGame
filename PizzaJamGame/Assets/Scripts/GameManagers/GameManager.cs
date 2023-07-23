using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance
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

    public bool isOnUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
