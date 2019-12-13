public interface IInventoryItem
{
    InventoryItemObjectBase InventoryItemObject { get; }

    void OnPickup();

    void OnDrop();
}
