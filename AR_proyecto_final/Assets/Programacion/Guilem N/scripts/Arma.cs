using UnityEngine;

public class Arma : MonoBehaviour
{

    public static Arma Instance;

    public int damage_enemy;
    
    public StatsInfo statsInfo_DMG_ENEMY;

    private void OnEnable()
    {
        damage_enemy = (int)statsInfo_DMG_ENEMY.options_list_lvl[statsInfo_DMG_ENEMY.current_lvl];
    }
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("he entrado en el trigger");
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.TakeDamage(damage_enemy);
            
            Debug.Log("Has muerto");
        }
    }
}
