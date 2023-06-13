using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Loaded : MonoBehaviour
{      

    public float speed;

    public Vector3 playerPosition;


    private void OnEnable()
    {
        Invoke("Desactivate", 3f);
    }


    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Bullet_Damage_Loaded();  
            gameObject.SetActive(false);    
        }
    }

}
