using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Hability : MonoBehaviour
{
    
    

    public int damage_hability;

    public float speed;

    

    private void Start()
    {
        // Desactivar bala despres de 2 segons
        Invoke("DeactivateGameObj", 2f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<BasicEnemy>().TakeDamage(damage_hability);
            
            // Aina: Sistema Logros
            Sistema_Logros.instance.AddDamage_Achievement(damage_hability);
            // Aina: Json Local
            PlayerController.instance.player_data_localRequest.damageDone += damage_hability;
        }
    }
    
    private void DeactivateGameObj()
    {
        gameObject.SetActive(false);
    }
}
