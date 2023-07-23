using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PlayerMovement : MonoBehaviour
{

    // Private stuff
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private string groundTag;

    private RaycastHit rayHit;

    // Public stuff
    public Camera viewCamera;



    private void Update()
    {
        
        MovementProcess();
        
    }


    private void MovementProcess()
    {
        if (Input.GetMouseButtonDown(1))
            if(PlayerManager.Istance.playerState != PlayerManager.State.AttackingStart)
            {
                MoveToPosition(GetPosition());
                AnimateMovement();
                PlayerManager.Istance.playerState = PlayerManager.State.Moving;
            }
        if(PlayerManager.Istance.playerState == PlayerManager.State.AttackingStart && Input.GetKey(KeyCode.LeftShift))
            MoveToPosition(this.transform.position);
        
        
        
    }


    private Vector3 GetPosition()
    {
        Vector3 result;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
        {
            if (rayHit.collider.CompareTag(groundTag))
                result = rayHit.point;
            else
                result = transform.position;
            
        }

        else
            result = transform.position;    // Nothig will change


        return result;
    }


    private void MoveToPosition(Vector3 position)
    {
        agent.destination = position;
    }


    private void AnimateMovement()
    {
        // This will be unlocked after we get the assets
    }

    





}
