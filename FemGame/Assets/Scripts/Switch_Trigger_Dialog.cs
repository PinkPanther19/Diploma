using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Switch_Trigger_Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchToOnUse()
    {
        GetComponent<DialogueSystemTrigger>().trigger = DialogueSystemTriggerEvent.OnUse;
    }
}
