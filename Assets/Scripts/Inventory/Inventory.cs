using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS_COUNT = 8;
    private IList<IInventoryItem> items = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded = delegate { };
    public event EventHandler<InventoryEventArgs> ItemDropped = delegate { };

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

    public void DropItem(IInventoryItem item)
    {
        if(this.items.Remove(item))
        {
            item.OnDrop();
            Debug.Log("Drop item inventory");

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            Debug.Log("Drop item inventory2");
            if(collider != null)
            {
                collider.enabled = true;

                Debug.Log("HUD remove call");
                ItemDropped(this, new InventoryEventArgs(item));
            }
        }
    }
}
