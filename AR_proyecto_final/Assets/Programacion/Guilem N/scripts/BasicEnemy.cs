
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public GameObject respawn_enemigo;
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
            ++GameManager.instance.defeatedEnemies;
            GameManager.instance.WinCondition();
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }
    
}