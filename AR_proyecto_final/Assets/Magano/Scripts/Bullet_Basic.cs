using UnityEngine;

public class Bullet_Basic : MonoBehaviour
{
    public static Bullet_Basic instance;

    public int damage;
    public float speed;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        Invoke("DeactivateGameObj", 2f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("IMPACTO");
            other.GetComponent<BasicEnemy>().TakeDamage(damage);
           DeactivateGameObj();
            
            // Aina: Sistema Logros
            Sistema_Logros.instance.AddDamage_Achievement(damage);
            // Aina: Json Local
            PlayerController.instance.player_data_localRequest.damageDone += damage;
        }
        else if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss_Controleler>().TakeDamage(damage);
            
            // Aina: Sistema Logros
            Sistema_Logros.instance.AddDamage_Achievement(damage);
            // Aina: Json Local
            PlayerController.instance.player_data_localRequest.damageDone += damage;
        }
    }
    
    private void DeactivateGameObj()
    {
        gameObject.SetActive(false);
    }
}
