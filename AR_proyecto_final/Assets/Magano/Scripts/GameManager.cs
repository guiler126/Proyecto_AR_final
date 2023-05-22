using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Tooltip("Total number of enemies in the wave")]
    public int totalEnemies;
    
    [Tooltip("Number of enemies the player has eliminated")]
    public int defeatedEnemies;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WinCondition()
    {
        if (defeatedEnemies >= totalEnemies)
        {
            Ui_Manager.instance.WinCondition();
        }
    }
}
