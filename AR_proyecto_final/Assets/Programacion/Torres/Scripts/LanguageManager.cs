using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{

    private string currentLanguageCode;

    void Start()
    {
        currentLanguageCode = PlayerPrefs.GetString("Language", "en");
        // Seleccionar el idioma actual
        StartCoroutine(SetLanguageInGame());

       


    }

    public void SetLanguage(string newLanguageCode)
    {
        Dictionary<string, Locale> languageDic = new Dictionary<string, Locale>
        {
            {"en", LocalizationSettings.AvailableLocales.Locales[0]},
            {"es", LocalizationSettings.AvailableLocales.Locales[1]},
            {"fr", LocalizationSettings.AvailableLocales.Locales[2]},
            {"de", LocalizationSettings.AvailableLocales.Locales[3]}
        };

        if (languageDic.ContainsKey(newLanguageCode))
        {
            LocalizationSettings.SelectedLocale = languageDic[newLanguageCode];
        }
        PlayerPrefs.SetString("Language", newLanguageCode);
    }

    IEnumerator SetLanguageInGame()
    {
        yield return new WaitForSeconds(0.3f);
        SetLanguage(currentLanguageCode);
    }

}
