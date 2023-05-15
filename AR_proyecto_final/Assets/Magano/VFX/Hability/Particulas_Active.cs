using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas_Active : MonoBehaviour
{
    public GameObject objeto; // El objeto que se activar� o desactivar�.
    public KeyCode tecla = KeyCode.Space; // La tecla del teclado que activar� o desactivar� el objeto. Por defecto es la tecla Espacio.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            objeto.SetActive(!objeto.activeSelf); // Activa o desactiva el objeto seg�n su estado actual.
        }
    }
}
