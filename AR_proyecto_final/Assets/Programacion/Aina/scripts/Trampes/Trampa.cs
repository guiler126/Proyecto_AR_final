using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        // Aplicar amb script player o enemy
        if (other.GetComponent<Trampa_Parent>())
        {
            //other.GetComponent<Trampa_Parent>().liufe -= damage;
        }
    }
}
