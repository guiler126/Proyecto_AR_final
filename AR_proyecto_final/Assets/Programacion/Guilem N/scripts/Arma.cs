
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arma : MonoBehaviour
{

    public static Arma Instance;

    public int damage_enemy;
    
    private void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("he entrado en el trigger");
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.TakeDamage(damage_enemy);
            
            Debug.Log("Has muerto");
        }
    }
}
