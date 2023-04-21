using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static Camera instance;

    public float mouseSensiblity = 80f;
    public Transform playerBody;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0;
    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Accedemos a los axis del mouse
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        // Lógica para controlar el movimiento de la camara de arriba-abajo
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -70f, 70f); // Definimos lo que podemos subir máximo y lo que podemos bajar máximo

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // Aplicamos esa rotación a la camara

        // Rootamos al cuerpo de nuestro jugador de izquierda y derecha
        // Como nuestro cuerpo es padre de la camara la moverá también
        playerBody.Rotate(Vector3.up * mouseX * mouseSensiblity * Time.deltaTime);
    }
}
