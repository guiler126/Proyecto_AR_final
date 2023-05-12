using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
  
    public void SetLanguage(string newLanguageCode)
    {
        Dictionary<string, Locale> languageDic = new Dictionary<string, Locale>
        {
            {"es", LocalizationSettings.AvailableLocales.Locales[0]},
            {"en", LocalizationSettings.AvailableLocales.Locales[1]},
            {"fr", LocalizationSettings.AvailableLocales.Locales[2]},
            {"de", LocalizationSettings.AvailableLocales.Locales[3]},
        };


        if(languageDic.ContainsKey(newLanguageCode))
        {
            LocalizationSettings.SelectedLocale = languageDic[newLanguageCode];
        }


    }

}
