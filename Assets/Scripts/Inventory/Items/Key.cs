using UnityEngine;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour, IInventoryItem
{
	public string ItemName 
    {
        get
        {
            return "Key";
        }
    }

    [SerializeField]
	private Sprite _Image = null;
    public Sprite Image 
    {
        get
        {
            return this._Image;
        }
    }

	public void OnPickup()
	{
		this.gameObject.SetActive(false);
	}
}
