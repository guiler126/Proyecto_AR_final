
using System;
using UnityEngine;
using UnityEngine.AI;
public class enemigo : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject respawn;
   
    
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }

    
}
