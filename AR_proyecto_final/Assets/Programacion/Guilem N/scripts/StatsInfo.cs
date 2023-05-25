using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "new Stats Info", menuName = "Stats Info Data")]
public class StatsInfo : ScriptableObject
{
    public LocalizedString title;
    
    public LocalizedString description;

    public Sprite icon;
    
    public Sprite background;

    public bool maxLvl;
    
    public int current_lvl;
    
    public List<float> options_list_lvl;
    

}
