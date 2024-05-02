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
        // ������������� �� ������� ��������� �������� dropdown
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        // ������������� ������� ���� � dropdown
        SetCurrentLanguage();
    }

    private void OnLanguageChanged(int index)
    {
        // �������� ��������� ���� �� dropdown
        string selectedLanguage = GetLanguageFromIndex(index);

        // ������������� ���� � DialogueManager
        DialogueManager.SetLanguage(selectedLanguage);
    }

    private void SetCurrentLanguage()
    {
        // ������������� ������� ���� � dropdown
        string currentLanguage = "Ru";//DialogueManager.GetCurrentLanguage();
        languageDropdown.value = GetIndexFromLanguage(currentLanguage);
    }

    private string GetLanguageFromIndex(int index)
    {
        // ���������� ���� �� dropdown �� �������
        string[] languages = { "Ru", "EN" };
        return languages[index];
    }

    private int GetIndexFromLanguage(string language)
    {
        // ���������� ������ ����� � dropdown
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
