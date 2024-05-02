using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class FogSettingsController : MonoBehaviour
{
    public Color fogColor;
    public Light targetLight;
    public Color lightFilterColor;
    //Filter Color
    public Color startColorF = new Color(1.0f, 0.84f, 0.59f, 1.0f); // FFD696
    public Color endColorF = new Color(0.62f, 0.75f, 0.79f, 1.0f); //
    public float duration = 2.0f;
    //Fog Color
    public Color startColorFog; // FFD696
    public Color endColorFog; //

    //Temperature from DLight
    public float startTemperature = 3232.0f;
    public float endTemperature = 10304.0f;



    void Start()
    {
        RenderSettings.fogColor = fogColor;
    }
    
    void Update()
    {
        




        RenderSettings.fogColor = fogColor;

        if (targetLight != null)
        {
            targetLight.color = lightFilterColor;
        }
    }

    public void StartBadWeather()
    {
        StartCoroutine(ChangeColorOverTime());
    }

    IEnumerator ChangeColorOverTime()
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            lightFilterColor = Color.Lerp(startColorF, endColorF, elapsedTime / duration);
            fogColor = Color.Lerp(startColorFog, endColorFog, elapsedTime / duration);
            targetLight.colorTemperature = Mathf.Lerp(startTemperature, endTemperature, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        lightFilterColor = endColorF;
        RenderSettings.fogColor = fogColor;
        targetLight.colorTemperature = Mathf.Lerp(startTemperature, endTemperature, elapsedTime / duration);
    }
}
