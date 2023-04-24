
using UnityEngine;

public class Matar : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BasicEnemy.Instance.TakeDamage(50);
        }
    }
}
