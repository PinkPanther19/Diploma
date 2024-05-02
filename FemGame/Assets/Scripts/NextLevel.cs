using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public int nextLevel_int;
    // Start is called before the first frame update
    public Image transitionImage;
    public float transitionSpeed = 1.0f;

    public void StartScreenTransition()
    {
        StartCoroutine(TransitionAndLoad());
    }

    public void BlackImageON()
    {
        StartCoroutine(BlackImageStart_IE());
    }

    public void BlackImageOFF()
    {
        StartCoroutine(BlackImageOFF_IE());
    }
    IEnumerator TransitionAndLoad()
    {
        Color originalColor = transitionImage.color;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            transitionImage.color = Color.Lerp(Color.clear, Color.black, t);
            yield return null;
        }

        // Загрузка новой сцены
        SceneManager.LoadScene(nextLevel_int);

        // Плавное отключение изображения
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            transitionImage.color = Color.Lerp(Color.black, Color.clear, t);
            yield return null;
        }

        // Полное отключение изображения
        transitionImage.color = Color.clear;
    }

    IEnumerator BlackImageStart_IE()
    {

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            transitionImage.color = Color.Lerp(Color.clear, Color.black, t);
            yield return null;
        }
    }

    IEnumerator BlackImageOFF_IE()
    {
        float t = 0;
        
        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            transitionImage.color = Color.Lerp(Color.black, Color.clear, t);
            yield return null;
        }

        // Полное отключение изображения
        transitionImage.color = Color.clear;
    }

}
