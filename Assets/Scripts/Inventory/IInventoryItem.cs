using UnityEngine;

public interface IInventoryItem
{
    string ItemName { get; }
    Sprite Image { get; }

    void OnPickup();
}
