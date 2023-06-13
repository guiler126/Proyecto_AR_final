using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Loaded : MonoBehaviour
{      

    public float speed;

    public Vector3 playerPosition;


    void Start()
    {
        // me destruyo a mi mismo cada 5 segundos 
        Destroy(gameObject, 10);
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
