using UnityEngine;

[CreateAssetMenu()]
public class KeyItem : InventoryItemObjectBase
{
	public override string ItemName => "Ключ от какой-то двери";

    [SerializeField]
    private Sprite _Image;
	public override Sprite Image => this._Image;
    
}
