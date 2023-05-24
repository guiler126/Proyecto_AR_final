
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public PoolingItemsEnum enemyDie;
    public GameObject respawn_enemigo;
    public GameObject portal_enemigo;
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
        portal_enemigo = PoolingManager.Instance.GetPooledObject((int)enemyDie);

        if (portal_enemigo != null)
        {
            portal_enemigo.transform.position = gameObject.transform.position;
            portal_enemigo.gameObject.SetActive(true);
        }
        
        Invoke("Death", 2);
    }

    private void Death()
    {
        portal_enemigo.SetActive(false);
        gameObject.SetActive(false);
    }
    
}