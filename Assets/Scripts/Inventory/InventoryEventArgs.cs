using System;

public class InventoryEventArgs : EventArgs
{
    public IInventoryItem Item;

    public InventoryEventArgs(IInventoryItem item)
    {
        this.Item = item;
    }
}
