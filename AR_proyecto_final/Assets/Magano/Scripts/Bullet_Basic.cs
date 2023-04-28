using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Basic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemy.Instance.TakeDamage(10);
        }
    }
}
