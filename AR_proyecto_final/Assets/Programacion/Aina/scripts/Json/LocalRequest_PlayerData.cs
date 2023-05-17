using System.IO;
using UnityEngine;

public class LocalRequest_PlayerData : MonoBehaviour
{
    public static LocalRequest_PlayerData Instance;
    
    public Player_Data player_data_localRequest;
    [SerializeField] private GameObject content_playerdata_list;
    [SerializeField] private Item_playerdata_list itemPlayerdata;

    private string saveFile;
    
    private void Awake()
    {
        Instance = this;

        saveFile = Application.persistentDataPath + "/playerdata.json";
        
        Debug.Log(saveFile);

        Refresh_Sound_List();
    }
    
    [ContextMenu("Read")]
    public void ReadFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            
            // Work with JSON
            player_data_localRequest = JsonUtility.FromJson<Player_Data>(fileContents);

            Debug.Log(player_data_localRequest.damageDone);
            Debug.Log(player_data_localRequest.damageTaken);
        }
    }
    
    [ContextMenu("Write")]
    public void WriteFile()
    {
        File.WriteAllText(saveFile, JsonUtility.ToJson(player_data_localRequest));
    }
    
    public void Refresh_Sound_List()
    {
        Clean_Sound_List();
        ReadFile();
        
        Item_playerdata_list _itemPlayerdata;
        _itemPlayerdata = Instantiate(itemPlayerdata, content_playerdata_list.transform);
        _itemPlayerdata.timeTaken = player_data_localRequest.timeTaken;
        _itemPlayerdata.damageDone = player_data_localRequest.damageDone;
        _itemPlayerdata.damageTaken = player_data_localRequest.damageTaken;
        _itemPlayerdata.attack1UsedTimes = player_data_localRequest.attack1UsedTimes;
        _itemPlayerdata.attack2UsedTimes = player_data_localRequest.attack2UsedTimes;
        _itemPlayerdata.dashUsedTimes = player_data_localRequest.dashUsedTimes;
    }    
    
    private void Clean_Sound_List()
    {
        foreach (Transform child in content_playerdata_list.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
