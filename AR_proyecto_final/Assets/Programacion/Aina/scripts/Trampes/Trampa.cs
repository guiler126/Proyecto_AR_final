using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        // Aplicar amb script player o enemy
        if (other.GetComponent<PlayerController>())
        {
            //other.GetComponent<PlayerController>().liufe -= damage; -= damage;
        }
    }
}
