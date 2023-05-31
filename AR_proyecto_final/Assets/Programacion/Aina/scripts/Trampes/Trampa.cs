using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnEnable()
    {
        Invoke("ActiveCollider", 2);
    }

    private void OnDisable()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            Debug.Log("damage");
        }
        else if (other.GetComponent<BasicEnemy>())
        {
            other.GetComponent<BasicEnemy>().TakeDamage(damage);
        }
    }

    private void ActiveCollider()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
