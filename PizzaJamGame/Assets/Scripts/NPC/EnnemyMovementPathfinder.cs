using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovementPathfinder : MonoBehaviour
{
    public  NavMeshAgent agent;

    public Transform player;


    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

}
