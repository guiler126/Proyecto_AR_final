using System;
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

    private void Start()
    {
        // Desactivar bala despres de 2 segons
        Invoke("DeactivateGameObj", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemy.Instance.TakeDamage(damage_hability);
        }
    }
    
    private void DeactivateGameObj()
    {
        gameObject.SetActive(false);
    }
}
