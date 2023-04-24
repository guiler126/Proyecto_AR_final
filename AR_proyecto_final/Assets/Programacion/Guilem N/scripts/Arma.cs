
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arma : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    public Animator Animator;

    

    public void OnTriggerEnter(Collider other)
    {
        Animator.SetBool("Atacar", true);
        Debug.Log("he entrado en el trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Has muerto");
            SceneManager.LoadScene("pruevaGuillem");
            Animator.SetBool("Atacar", false);
        }
    }
}
