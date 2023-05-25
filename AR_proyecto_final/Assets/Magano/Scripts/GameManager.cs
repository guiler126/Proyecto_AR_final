using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Tooltip("Total number of enemies in the wave")]
    private int totalEnemies;
    
    [Tooltip("Number of enemies the player has eliminated")]
    public int defeatedEnemies;

    [SerializeField] private int pointStats;
    
    public int TotalEnemies
    {
        get {return totalEnemies; }
        set {totalEnemies = value; }
    }
    
    public int DefeatedEnemies
    {
        get {return defeatedEnemies; }
        set {defeatedEnemies = value; }
    }
    
    public int PointStats
    {
        get {return pointStats; }
        set {pointStats = value; }
    }

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

        pointStats = 2;
    }

    public void WinCondition()
    {
        if (defeatedEnemies >= totalEnemies)
        {
            int value = 0;
            
            if (Sistema_Missions.instance.MissionsCompleted >= 2)
            {
                value = 1;
            }
            
            Mission_Fixed.instance.EndGame_CheckerMision();
            pointStats = value + 1;
            Ui_Manager.instance.WinCondition();
        }
    }
}
