
using System;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public PoolingItemsEnum enemyDie_1;
    public GameObject respawn_enemigo;
    public GameObject particles_enemigo;
    [Header("Stats")]
    public float health;
    public Animator Animator;

    public int Enemy_kill_damage = 100;

    private bool death;
    
    public StatsInfo statsInfo_hEALTH_ENEMY;


    public Material default_material;
    public Material dissolve_material;
    public SkinnedMeshRenderer SkinnedMeshRenderer;
    
    
    private void OnEnable()
    {
        health = (int)statsInfo_hEALTH_ENEMY.options_list_lvl[statsInfo_hEALTH_ENEMY.current_lvl];

        SkinnedMeshRenderer.materials[0] = dissolve_material;

        dissolve_material.SetFloat("_DissolveAmount", 0f);
        

        death = false;
    }
    

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !death)
        {
            death = true;

            Animator.SetTrigger("Morrir");
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;

            SkinnedMeshRenderer.materials[0] = dissolve_material;
            health = (int)statsInfo_hEALTH_ENEMY.options_list_lvl[statsInfo_hEALTH_ENEMY.current_lvl];
            ++GameManager.instance.DefeatedEnemies;
            ++Mission_Fixed.instance.EnemiesEliminated;
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