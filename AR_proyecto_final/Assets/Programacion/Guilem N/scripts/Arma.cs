
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arma : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("he entrado en el trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Has muerto");
            SceneManager.LoadScene("pruevaGuillem");
        }
    }
}
