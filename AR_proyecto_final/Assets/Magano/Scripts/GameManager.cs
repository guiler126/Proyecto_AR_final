using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Tooltip("Total number of enemies in the wave")]
    private int totalEnemies;
    
    [Tooltip("Number of enemies the player has eliminated")]
    public int defeatedEnemies;

    private int pointStats;

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
    }

    public void WinCondition()
    {
        if (defeatedEnemies >= totalEnemies)
        {
            Mission_Fixed.instance.EndGame_CheckerMision();
            pointStats = Sistema_Missions.instance.MissionsCompleted + 1;
            Debug.Log(pointStats);
            Ui_Manager.instance.WinCondition();
        }
    }
}
