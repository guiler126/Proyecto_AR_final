using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_1 : MonoBehaviour
{
    public float speed;

    public Vector3 playerPosition;

    private void OnEnable()
    {
        Invoke("Desactivate", 3f);
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Bullet_Damage();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Level"))
        {
            Desactivate();
        }
    }
}
