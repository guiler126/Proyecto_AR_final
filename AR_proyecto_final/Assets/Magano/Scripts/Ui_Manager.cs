using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Manager : MonoBehaviour
{
    public static Ui_Manager instance;
    
    [SerializeField] private GameObject win_Panel;
    [SerializeField] private GameObject lose_Panel;
    [SerializeField] private TMP_Text pointStats_txt;
    public Slider slider_health;

    public PoolingItemsEnum enemy;

    [Header("----- Mejora List -----")]
    public List<StatsInfo> _statsInfoPlayer;
    public List<StatsInfo> _statsInfoEnemy;
    public List<StatsInfo> _randomStatsInfos;
    [SerializeField] private GameObject content_mejora_list;
    [SerializeField] private Item_Mejora item_mejora_list;

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
        win_Panel.SetActive(true);
        RefreshTxtPoints();
        Refresh_Mejora_List();
        Time.timeScale = 0;
    }
    
    public void LoseCondition()
    {
        lose_Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RefreshTxtPoints()
    {
        pointStats_txt.text = $"{GameManager.instance.PointStats}";
    }

    public void NextRound()
    {
        Time.timeScale = 1;
        win_Panel.SetActive(false);
        PoolingManager.Instance.DesactivatePooledObject((int)enemy);
        Sistema_Oleadas.Instance.Checker();
        Sistema_Missions.instance.StartMissionRound();
        ++GetRandomValue(_statsInfoEnemy).current_lvl;
        Upgrade_Manager_Enemy.instace.RefreshAllStats();
        GameManager.instance.DefeatedEnemies = 0;
    }
    
    public void RestartRound()
    {
        Time.timeScale = 1;
        lose_Panel.SetActive(false);
        PoolingManager.Instance.DesactivatePooledObject((int)enemy);
        Sistema_Oleadas.Instance.Checker();
        Sistema_Missions.instance.StartMissionRound();
        PlayerController.instance.isDie = false;
        PlayerController.instance.health = 5;
        LookAtMouse.instance.enabled = true;
        GameManager.instance.DefeatedEnemies = 0;
    }

    public void Refresh_Mejora_List()
    {
        Clean_Sound_List();

        _randomStatsInfos = new List<StatsInfo>();
        _randomStatsInfos = GetRandomValuesFromList(_statsInfoPlayer, 3);

        foreach (var mejora in _randomStatsInfos)
        {
            Item_Mejora _item_mejora_list;
            _item_mejora_list = Instantiate(item_mejora_list, content_mejora_list.transform);
            _item_mejora_list.title = mejora.title;
            _item_mejora_list.description = mejora.description;
            _item_mejora_list.icon.sprite = mejora.icon;
            _item_mejora_list.background.sprite = mejora.background;
            _item_mejora_list.name = mejora.name;
            _item_mejora_list._statsInfo = mejora;
        }
    }    

    private void Clean_Sound_List()
    {
        foreach (Transform child in content_mejora_list.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    
    private List<StatsInfo> GetRandomValuesFromList(List<StatsInfo> list, int count)
    {
        List<StatsInfo> randomValues = new List<StatsInfo>();
        System.Random random = new System.Random();
        int statsNoMaxLvl = 0;
        
        foreach (var value in list)
        {
            if (!value.maxLvl)
            {
                ++statsNoMaxLvl;
            }
        }

        if (statsNoMaxLvl < count)
        {
            count = statsNoMaxLvl;
        }
        
        // Obtener índices aleatorios hasta obtener la cantidad deseada
        while (randomValues.Count < count)
        {
            int randomIndex = random.Next(0, list.Count);

            // Asegurarse de que el valor no se repita
            if (!randomValues.Contains(list[randomIndex]) && !list[randomIndex].maxLvl)
            {
                randomValues.Add(list[randomIndex]);
            }
        }

        return randomValues;
    }
    
    private StatsInfo GetRandomValue(List<StatsInfo> list)
    {
        StatsInfo randomValue = null;
        System.Random random = new System.Random();

        // Obtener índices aleatorios hasta obtener la cantidad deseada
        while (randomValue == null)
        {
            int randomIndex = random.Next(0, list.Count);

            // Asegurarse de que el valor no se repita
            if (!list[randomIndex].maxLvl)
            {
                randomValue = list[randomIndex];
            }
        }
        
        return randomValue;
    }


}
