using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MousePos : MonoBehaviour
    {
        #region Singleton
        private static MousePos _instance;
        public static MousePos Instance
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
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask layerMask;
        public Vector3 mousePOS;

        private void Update()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue , layerMask))
            {
                mousePOS = raycastHit.point;
                transform.position = raycastHit.point;
            }
        }
    }

