using TMPro;
using UnityEngine;

public class Item_playerdata_list : MonoBehaviour
{
    public float timeTaken;
    public int attack1UsedTimes;
    public int attack2UsedTimes;
    public int dashUsedTimes;
    public int damageDone;
    public int damageTaken;

    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{timeTaken}";
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{attack1UsedTimes}";
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"{attack2UsedTimes}";
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"{dashUsedTimes}";
        transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = $"{damageDone}";
        transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = $"{damageTaken}";
    }
}
