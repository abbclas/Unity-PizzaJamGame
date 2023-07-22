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
        if (Input.GetMouseButtonDown(1))
            MovementProcess();
        
    }


    private void MovementProcess()
    {
        MoveToPosition(GetPosition());
        AnimateMovement();
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
        agent.SetDestination(position);
    }


    private void AnimateMovement()
    {
        // This will be unlocked after we get the assets
    }

    





}
