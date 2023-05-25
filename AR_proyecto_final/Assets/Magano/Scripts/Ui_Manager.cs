using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public static Ui_Manager instance;
    
    public GameObject health_1;
    public GameObject health_2;
    public GameObject health_3;
    public GameObject health_4;
    public GameObject health_5;

    [SerializeField] private GameObject win_Panel;
    [SerializeField] private GameObject lose_Panel;
    [SerializeField] private TMP_Text pointStats_txt;

    public PoolingItemsEnum enemy;

    [Header("----- Mejora List -----")]
    public List<StatsInfo> _statsInfoPlaye;
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

    private void Start()
    {
        Refresh_Mejora_List();
    }

    private void Update()
    {
        //Update_Health();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Refresh_Mejora_List();
        }
    }

    public void Update_Health()
    {
        if (PlayerController.instance.health == 4)
        {
            health_5.SetActive(false);
        }

        if (PlayerController.instance.health == 3)
        {
            health_4.SetActive(false);
        }
        if (PlayerController.instance.health == 2)
        {
            health_3.SetActive(false);
        }
        if (PlayerController.instance.health == 1)
        {
            health_2.SetActive(false);
        }
        if (PlayerController.instance.health <= 0)
        {
            health_1.SetActive(false);
        }
    }

    public void WinCondition()
    {
        pointStats_txt.text = $"{GameManager.instance.PointStats}";
        win_Panel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void LoseCondition()
    {
        lose_Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextRound()
    {
        Time.timeScale = 1;
        win_Panel.SetActive(false);
        PoolingManager.Instance.DesactivatePooledObject((int)enemy);
        Sistema_Oleadas.Instance.Checker();
        Sistema_Missions.instance.StartMissionRound();
    }

    public void Refresh_Mejora_List()
    {
        Clean_Sound_List();

        _randomStatsInfos = new List<StatsInfo>();
        _randomStatsInfos = GetRandomValuesFromList(_statsInfoPlaye, 3);

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
}
