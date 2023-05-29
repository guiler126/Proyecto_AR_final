using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Item_Mejora : MonoBehaviour
{
    public LocalizedString title;
    
    public LocalizedString description;

    public Image icon;
    
    public Image background;

    public GameObject content;
    
    public GameObject star;

    public StatsInfo _statsInfo;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Mejora);

        if (_statsInfo != null)
        {
            for (int i = 0; i < _statsInfo.current_lvl + 1; i++)
            {
                Instantiate(star, content.transform);
            }
        }
    }

    private void Mejora()
    {
        if (GameManager.instance.PointStats > 0)
        {
            --GameManager.instance.PointStats;
            _statsInfo.current_lvl++;
            Ui_Manager.instance.RefreshTxtPoints();
            Upgrade_Manager_Player.instace.RefreshAllStats();
            gameObject.SetActive(false);
        }
    }
}
