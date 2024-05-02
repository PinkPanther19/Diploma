using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioIsPlay : MonoBehaviour
{
    public AudioSource MySourse;
    public bool isPlayed = false;
    public AudioSource NextSourse;

    private float startVolume;
    public float fadeOutTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        MySourse = gameObject.GetComponent<AudioSource>();
        startVolume = NextSourse.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (MySourse.isPlaying == false && isPlayed == true)
        {
            NextSourse.Play();
            isPlayed = false;
        }
    }

    public void NextAudio()
    {
        isPlayed = true;
    }

    public void FadeOutSound()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (NextSourse.volume > 0)
        {
            NextSourse.volume -= startVolume * Time.deltaTime / fadeOutTime;
            yield return null;
        }
        NextSourse.Stop();
    }


}
