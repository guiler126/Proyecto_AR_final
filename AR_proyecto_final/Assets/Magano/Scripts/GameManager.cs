using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Tooltip("Total number of enemies in the wave")]
    private int totalEnemies;
    
    [Tooltip("Number of enemies the player has eliminated")]
    public int defeatedEnemies;

    [SerializeField] private int pointStats;

    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject player;
    
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
            Mission_Fixed.instance.EndGame_CheckerMision();

            int value = 0;
            value = Sistema_Missions.instance.MissionsCompleted;
            
            if (value > 2)
            {
                value = 2;
            }
            else if (value < 0)
            {
                value = 0;
            }

            pointStats = value + 1;
            Invoke("UIWin", 5);
        }
    }

    private void UIWin()
    {
        Ui_Manager.instance.WinCondition();
    }

    public void ResetPlayerPosition()
    {
        Debug.Log("spwn");
        PlayerController.instance._characterController.enabled = false;
        player.transform.position = Vector3.zero;
        PlayerController.instance._characterController.enabled = true;
    }
}
