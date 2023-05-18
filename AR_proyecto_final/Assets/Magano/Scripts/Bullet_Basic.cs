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
        }
    }
    
    private void DeactivateGameObj()
    {
        gameObject.SetActive(false);
    }
}
