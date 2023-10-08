using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branchSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void branchSoundON()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
