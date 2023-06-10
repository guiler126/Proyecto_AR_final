using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class Item_logros_list : MonoBehaviour
{
    public Image sprite;
    public LocalizedString title;
    public LocalizeStringEvent _localizeStringEventTitle;
    public Slider logro_1;
    public Slider logro_2;
    public Slider logro_3;
    
    public TMP_Text textTotal_1;
    
    public TMP_Text textTotal_2;
    
    public TMP_Text textTotal_3;

    private void Start()
    {
        _localizeStringEventTitle.StringReference.TableReference = title.TableReference;
        _localizeStringEventTitle.StringReference.TableEntryReference = title.TableEntryReference;
    }
}
