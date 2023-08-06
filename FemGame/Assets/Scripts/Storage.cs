using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Storage : ScriptableObject
{
    static Storage instance;
    // Start is called before the first frame update
    public List<Item> AllItems;
    public Item GetItem(string name) => AllItems.Find(i => i.Name == name);
    public static Storage GetStorage()
    {
        if (!instance)
        {
            instance = Resources.Load("Storage") as Storage;

        }

        return instance;
    }

}
