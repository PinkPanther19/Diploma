using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
  public bool isFullScreen;
    // Start is called before the first frame update
      public void FullScreenToggle()
    {
        isFullScreen = Screen.fullScreen;
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
}
