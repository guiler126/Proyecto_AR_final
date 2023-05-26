
using System;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public PoolingItemsEnum enemyDie_1;
    public GameObject respawn_enemigo;
    public GameObject particles_enemigo;
    [Header("Stats")]
    public int health;
    public Animator Animator;

    public int Enemy_kill_damage = 100;

    private bool death;
    
    public StatsInfo statsInfo_hEALTH_ENEMY;
    
    private void OnEnable()
    {
        health = (int)statsInfo_hEALTH_ENEMY.options_list_lvl[statsInfo_hEALTH_ENEMY.current_lvl];
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 && !death)
        {
            death = true;

            Animator.SetTrigger("Morrir");
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            ++GameManager.instance.DefeatedEnemies;
            GameManager.instance.WinCondition();
        }
    }

    public void DeathPortal()
    {
        particles_enemigo = PoolingManager.Instance.GetPooledObject((int)enemyDie_1);

        if (particles_enemigo != null)
        {
            particles_enemigo.transform.position = gameObject.transform.position;
            particles_enemigo.gameObject.SetActive(true);
        }
    }

    public void Death()
    {
        particles_enemigo.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            TakeDamage(other.gameObject.GetComponent<Bullet_Basic>().damage);
        }
    }
}