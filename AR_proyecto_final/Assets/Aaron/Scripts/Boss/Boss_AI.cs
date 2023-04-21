using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public Animator anim;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if(navMeshAgent.speed >= 0.1f) 
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }
    }

    public void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.position);
    }


}
