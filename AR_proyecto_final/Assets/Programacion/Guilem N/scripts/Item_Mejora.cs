using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
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

    public LocalizeStringEvent _localizeStringEventTitle;
    public LocalizeStringEvent _localizeStringEventDescription;
    
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

        _localizeStringEventTitle.StringReference.TableReference = title.TableReference;
        _localizeStringEventTitle.StringReference.TableEntryReference = title.TableEntryReference;
        _localizeStringEventDescription.StringReference.TableReference = description.TableReference;
        _localizeStringEventDescription.StringReference.TableEntryReference = description.TableEntryReference;
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


