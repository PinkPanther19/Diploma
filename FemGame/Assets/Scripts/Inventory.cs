using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public Action<Item> onItemAdded;
    [FormerlySerializedAs("startItems")] public List<Item> startItems = new List<Item>();
    //List<Item> inventoryItems = new List<Item>();
    public List<Item> InventoryItems {get; private set;}
    void Awake()
    {
        InventoryItems = new List<Item>();

        var storage = Storage.GetStorage();
        //AddItem(storage.GetItem("firewood"));

    }

    public void AddItem(Item item)
    {
        InventoryItems.Add(item);

        onItemAdded?.Invoke(item);
    }


}
