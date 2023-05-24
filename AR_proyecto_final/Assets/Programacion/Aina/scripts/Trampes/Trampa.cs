using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().health -= damage;
        }
        else if (other.GetComponent<BasicEnemy>())
        {
            other.GetComponent<BasicEnemy>().health -= damage;
        }
    }
}
