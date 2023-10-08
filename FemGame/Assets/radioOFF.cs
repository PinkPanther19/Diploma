using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioOFF : MonoBehaviour
{
    private bool isPlay = false;
    private AudioSource AudioRadio;
    // Start is called before the first frame update
    void Start()
    {
        AudioRadio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay && AudioRadio.isPlaying == true )
        {
            AudioRadio.volume -= 0.1f *  Time.deltaTime;
            if(AudioRadio.volume  <= 0 )
            {
                AudioRadio.Stop();
            }
        }
    }

    public void OffRadio()
    {
        isPlay = true;
    }
}
