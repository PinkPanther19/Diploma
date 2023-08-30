using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemData", menuName = "New Item/Item")]

public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;
    //public GameObject gameObject;

    public static Item Load(string name)
    {
       // gameObject.enable = true;
        return Resources.Load("Items" + name) as Item;
    }
}
