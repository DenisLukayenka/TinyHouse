using UnityEngine;

public class ItemBase : MonoBehaviour, IInventoryItem
{
    private string _ignoreLayer = "Walls";

	public virtual string ItemName => "Base_item";

    public Sprite _Image = null;
	public Sprite Image => this._Image;

	public virtual void OnPickup()
	{
		this.gameObject.SetActive(false);
	}

	public virtual void OnDrop()
	{
		RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = ~(1 << LayerMask.NameToLayer(_ignoreLayer));

        if(Physics.Raycast(ray, out hit, 1000, mask, QueryTriggerInteraction.Collide))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
	}
}
