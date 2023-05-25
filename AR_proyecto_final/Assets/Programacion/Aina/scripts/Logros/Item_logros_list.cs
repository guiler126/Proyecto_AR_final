using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Item_logros_list : MonoBehaviour
{
    public Sprite sprite;
    public LocalizedString title;
    public LocalizedString description;
    public int numVar;

    void Start()
    {
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"{numVar}";
    }
}
