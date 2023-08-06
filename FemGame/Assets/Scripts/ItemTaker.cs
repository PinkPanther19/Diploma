using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
   // [SerializeField] Item itemToAdd;
    [SerializeField] Inventory targetInventory;
    [SerializeField] Interactive interactiveS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     targetInventory.AddItem(interactiveS.ItemName);
        // }
        if(interactiveS.ItemName != null)
        {
            targetInventory.AddItem(interactiveS.ItemName);
            interactiveS.ItemName = null;
        }
        
    }
}
