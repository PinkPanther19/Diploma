using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemData", menuName = "New Item/Item")]

public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;

    public static Item Load(string name)
    {
        return Resources.Load("Items" + name) as Item;
    }
}
