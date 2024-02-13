using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeController : MonoBehaviour
{
    [SerializeField] private GameObject PanelUIImage;

    [SerializeField] private Image imageVIPWarningPanel;

    [SerializeField] private float stepForAlpha = 0.01f;
    [SerializeField] private float timeUpdateAlpha = 0.02f;

    [SerializeField] private GameObject DialogManager_History;
    [SerializeField] private GameObject DialogManager_Emma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowPanelVIPCenter()
    {
        float alpha = 1f;
        while (imageVIPWarningPanel.color.a >0)
        {
            alpha -= stepForAlpha;
            imageVIPWarningPanel.color = new Color(1f, 1f, 1f, alpha);

            yield return new WaitForSeconds(timeUpdateAlpha);


        }

        if(imageVIPWarningPanel.color.a <= 0)
        {
            PanelUIImage.SetActive(false);
            DialogManager_History.SetActive(false);
            DialogManager_Emma.SetActive(true);
            yield return null;
        }
    }

    public void StartFadeImage()
    {
        StartCoroutine(ShowPanelVIPCenter());
    }
}
