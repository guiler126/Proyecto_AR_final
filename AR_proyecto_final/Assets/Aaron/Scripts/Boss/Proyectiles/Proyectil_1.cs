using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_1 : MonoBehaviour
{
    public float speed;

    public Vector3 playerPosition;

    private void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Start()
    {
        // me destruyo a mi mismo cada 5 segundos 
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
    }


}
