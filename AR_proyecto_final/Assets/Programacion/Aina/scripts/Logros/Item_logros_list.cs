using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_logros_list : MonoBehaviour
{
    public Sprite sprite;
    public string title;
    public string description;
    public int numVar;

    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = description;
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"{numVar}";
    }
}
