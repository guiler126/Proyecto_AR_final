using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 7f;


    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirecion = new Vector3(horizontalInput, 0 , verticalInput);

        transform.position = transform.position + movementDirecion * speed * Time.deltaTime;
    }
}
