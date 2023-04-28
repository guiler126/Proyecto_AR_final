

using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public static BasicEnemy Instance;
    public GameObject respawn_enemigo;
    [Header("Stats")]
    public int health;
    public Animator Animator;

    public int Enemy_kill_damage = 100;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Animator.SetTrigger("Morrir");
            enemigo.Instance.navMeshAgent.isStopped = true;
        }
    }
    
}