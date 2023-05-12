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
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

        //traslado mi posición hacia adelante 
        StartCoroutine(disparo());
    }

    IEnumerator disparo()
    {
        yield return new WaitForSeconds(0.1f);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 0.1f);
            yield return null;
        }
    }
}
