
using System;
using UnityEngine;
using UnityEngine.AI;
public class enemigo : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject respawn;
    public Animator Animator;
    
    
    void Start()
    {
        Animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator.SetBool("Atacar", true);
            navMeshAgent.speed = 0f;
            navMeshAgent.angularSpeed = 0f;
            navMeshAgent.acceleration = 0f;
        }
    }

    public void Terminar_Ataque()
    {
        Animator.SetBool("Atacar", false);
        navMeshAgent.speed = 5.5f;
        navMeshAgent.angularSpeed = 120f;
        navMeshAgent.acceleration = 8f;
    }
}
