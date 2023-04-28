
using System;
using UnityEngine;
using UnityEngine.AI;
public class enemigo : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject respawn;
    public Animator Animator;
    public static enemigo Instance;


    public bool isInAttackRange;
    public float attackRange;
    public LayerMask playerMask;
    
    
    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Miramos si el player está dentro de nuestro rango de ataque
        isInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
        
        if (isInAttackRange)
        {
            // Lógica atacar
            Animator.SetBool("Atacar", true);
            navMeshAgent.speed = 0f;
            navMeshAgent.isStopped = true;
        }
        else
        {
            // Lógica perseguir
            navMeshAgent.SetDestination(player.position);
        }

    }
    
    public void Terminar_Ataque()
    {
        Animator.SetBool("Atacar", false);
        navMeshAgent.speed = 7f;
        navMeshAgent.isStopped = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
