using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Hability : MonoBehaviour
{
    
    public static Bullet_Hability instance;

    public int damage_hability;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemy.Instance.TakeDamage(damage_hability);
        }
    }
}
