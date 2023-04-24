

using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public static BasicEnemy Instance;
    public GameObject respawn_enemigo;
    [Header("Stats")]
    public int health;
    
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
            transform.position = respawn_enemigo.transform.position;
            health = 100; 
        }
    }
}