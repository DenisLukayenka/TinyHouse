using UnityEngine;

public abstract class InventoryItemObjectBase: ScriptableObject
{
    public virtual string ItemName { get; } = "Unknown";

    public abstract Sprite Image { get; }   
}
