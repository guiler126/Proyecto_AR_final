using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Stats Info", menuName = "Stats Info Data")]
public class StatsInfo : ScriptableObject
{

    public int current_lvl;
    
    public List<float> options_list_lvl;

}
