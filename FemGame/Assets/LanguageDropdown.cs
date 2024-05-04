using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class LanguageDropdown : MonoBehaviour
{

    public Dropdown languageDropdown;
    //public DialogueManager dialogueManager;

    private void Start()
    {
        // Подписываемся на событие изменения значения dropdown
        languageDropdown = gameObject.GetComponent<Dropdown>();
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        // Устанавливаем текущий язык в dropdown
        SetCurrentLanguage();
    }

    public void OnLanguageChanged(int index)
    {
        // Получаем выбранный язык из dropdown
        string selectedLanguage = GetLanguageFromIndex(index);

        // Устанавливаем язык в DialogueManager
        DialogueManager.SetLanguage(selectedLanguage);
    }

    public void SetCurrentLanguage()
    {
        // Устанавливаем текущий язык в dropdown
        string currentLanguage = "";//DialogueManager.GetCurrentLanguage();
        languageDropdown.value = GetIndexFromLanguage(currentLanguage);
    }

    private string GetLanguageFromIndex(int index)
    {
        // Возвращаем язык из dropdown по индексу
        string[] languages = { "Ru", "EN" };
        return languages[index];
    }

    private int GetIndexFromLanguage(string language)
    {
        // Возвращаем индекс языка в dropdown
        string[] languages = { "Ru", "EN" };
        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i] == language)
            {
                return i;
            }
        }
        return 0;
    }

}
