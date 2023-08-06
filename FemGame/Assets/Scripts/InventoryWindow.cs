using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;

    readonly List<GameObject> drawnIcons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        targetInventory.onItemAdded += OnItemAdded;
        Redraw();
        
    }

    void OnItemAdded(Item obj) => Redraw();
    

    // Update is called once per frame
    void Redraw()
    {
        ClearDrawn();
        for (var i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item = targetInventory.InventoryItems[i];

            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Icon;
            
            icon.transform.SetParent(itemsPanel);

            drawnIcons.Add(icon);
        }
    }

    void ClearDrawn()
    {
        for (var i = 0; i < drawnIcons.Count; i++)
        {
            Destroy(drawnIcons[i]);
        }

        drawnIcons.Clear();
    }
}
