public interface IInventoryItem
{
    InventoryItemObjectBase InventoryItemObject { get; }

    void OnPickup();

    bool OnDrop();
}
