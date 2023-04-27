using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public Animator anim;

    public bool initialAnimCompleted;

    public static Boss_AI instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialAnimCompleted = false;
        StartCoroutine(SpawnBoss());
    }

    void Update()
    {
        if (navMeshAgent.isStopped) return;

        if (!initialAnimCompleted) return; 

       ChasePlayer();
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(2f);    
        navMeshAgent.SetDestination(player.position);
        initialAnimCompleted = true;
    }

    public void ChasePlayer()
    {
        if (navMeshAgent.speed >= 0.1f)
        {
            anim.SetBool("Walk", true);
            navMeshAgent.SetDestination(player.position);
        }

        if (Boss_Controleler.instance.HP <= 0)
        {
            navMeshAgent.speed = 0;
            navMeshAgent.isStopped = true;  
        }
    }


}
