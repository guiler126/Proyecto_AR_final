using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour
{
    public static Bullet_Basic instance;

    public int damage;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        Invoke("DeactivateGameObj", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemy.Instance.TakeDamage(damage);
            
            // Aina: Sistema Logros
            Sistema_Logros.instance.AddDamage_Achievement(damage);
            // Aina: Json Local
            PlayerController.instance.player_data_localRequest.damageDone += damage;
        }
    }
    
    private void DeactivateGameObj()
    {
        gameObject.SetActive(false);
    }
}
