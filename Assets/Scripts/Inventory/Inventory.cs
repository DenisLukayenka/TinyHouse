using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS_COUNT = 8;
    private IList<IInventoryItem> items = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded = delegate{};

    public void AddItem(IInventoryItem item)
    {
        if(items.Count < SLOTS_COUNT)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if(collider != null)
            {
                collider.enabled = false;
                items.Add(item);
                item.OnPickup();

                ItemAdded(this, new InventoryEventArgs(item));
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
