using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocalizationManager : MonoBehaviour
{
    public Language language;
    public enum Language
    {
        ENGLISH,
        SPANISH,
        CATALAN,
    }

    private List<string> _keys = new List<string>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        ReadFile();
        SetLanguage(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        SceneManager.sceneLoaded += SetLanguage;
    }

    private void ReadFile()
    {
        foreach (string localizationString in Resources.Load<TextAsset>("Localization/Localization").ToString().Split('\n'))
        {
            _keys.Add(localizationString);
        }

        _keys.RemoveAt(0);
    }

    private void SetLanguage(Scene scene, LoadSceneMode mode)
    {
        LocalizationKey[] localizationKeys = FindObjectsOfType<LocalizationKey>(true);

        foreach(LocalizationKey localizationKey in localizationKeys)
        {
            SetLocalizationKey(localizationKey, language);
        }
    }

    private void SetLocalizationKey(LocalizationKey localizationKey, Language language)
    {
        string targetKey = localizationKey.GetKey();

        foreach(string keyString in _keys)
        {
            if(targetKey == keyString.Split(';')[0])
            {
                localizationKey.SetKeyText(keyString.Split(';')[(int)language + 1]);
                return;
            }
            else
            {
                localizationKey.SetKeyText("KEY NOT FOUND.");
            }
        }
    }
}