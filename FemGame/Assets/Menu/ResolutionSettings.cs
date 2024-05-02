using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public Dropdown dropdown;
    Resolution[] res;
   // FullScreen checkFullScreen = GetComponent<FullScreen>();

  // GameObject.Find("Settings").GetComponent(typeof(FullScreen)).isFullScreen; //провальная попытка взять переменную из скрипта

    void Start()
    {
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string [] strRes = new string[res.Length];
        for(int i = 0; i<res.Length; i++)
        {
           
           strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        }
        dropdown.ClearOptions();

        dropdown.AddOptions(strRes.ToList());
        Screen.SetResolution(res[res.Length-1].width, res[res.Length-1].height, isFullScreen); //true - значит полноэкранный режим
    }

    public bool isFullScreen;
    // Start is called before the first frame update
      public void FullScreenToggle()
    {
        isFullScreen = Screen.fullScreen;
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SetRes()
    {
         Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, isFullScreen); //true - значит полноэкранный режим
  
    }
}
