
using System;
using UnityEngine;
using UnityEngine.AI;
public class enemigo : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject respawn;
    public Animator Animator;

    public bool isInAttackRange;
    public float attackRange;
    public LayerMask playerMask;

    public StatsInfo statsInfo_speed_ENEMY;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        navMeshAgent.speed = statsInfo_speed_ENEMY.options_list_lvl[statsInfo_speed_ENEMY.current_lvl];
    }
    
    void Start()
    {
        Animator = GetComponent<Animator>();
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
            if (navMeshAgent.enabled)
            {
                navMeshAgent.SetDestination(player.position);
            }
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
