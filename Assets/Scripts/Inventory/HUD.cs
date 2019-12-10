using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    
    void Start()
    {
        Inventory.ItemAdded += OnItemAddedToInventory;
    }

    private void OnItemAddedToInventory(object sender, InventoryEventArgs args)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        Debug.Log("Fount Inventory panel: " + inventoryPanel);

        foreach(Transform slot in inventoryPanel)
        {
            Debug.Log(slot);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                Debug.Log("Item Added222");

                image.enabled = true;
                image.sprite = args.item.Image;

                break;
            }
        }
    }
}
