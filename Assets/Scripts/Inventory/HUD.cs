using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    
    void Start()
    {
        Inventory.ItemAdded += OnItemAddedToInventory;
        Inventory.ItemDropped += OnItemDroppedFromInventory;
    }

    private void OnItemAddedToInventory(object sender, InventoryEventArgs args)
    {
        Transform inventoryPanel = transform.Find("Inventory");

        foreach(Transform slot in inventoryPanel)
        {
            Transform imageSlot = slot.GetChild(0).GetChild(0);
            Image image = imageSlot.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageSlot.GetComponent<ItemDragHandler>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = args.Item.Image;
                itemDragHandler.Item = args.Item;
                break;
            }
        }
    }

    private void OnItemDroppedFromInventory(object sender, InventoryEventArgs args)
    {
        Transform inventoryPanel = transform.Find("Inventory");

        Debug.Log("Start removing");
        foreach(Transform slot in inventoryPanel)
        {
            Transform imageSlot = slot.GetChild(0).GetChild(0);
            Image image = imageSlot.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageSlot.GetComponent<ItemDragHandler>();

            if(itemDragHandler.Item == args.Item)
            {
                Debug.Log("Found slot");
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }
        }
    }
}
