using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class InstantiateDialog : MonoBehaviour
{
    public TextAsset ta;
    public Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = Dialog.Load(ta);
        foreach(Node nd in dialog.nodes)
        {
            Debug.Log(nd.NpcText);
            foreach (Answer an in nd.answers)
            {
               // Debug.logger(an.text);
            }
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
