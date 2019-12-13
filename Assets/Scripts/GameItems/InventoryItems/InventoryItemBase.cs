using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    private string _ignoreLayer = "Walls";

	[SerializeField]
	public InventoryItemObjectBase _InventoryItemObject;
	public InventoryItemObjectBase InventoryItemObject => this._InventoryItemObject;

	public virtual void OnPickup()
	{
		this.gameObject.SetActive(false);
	}

	public virtual bool OnDrop()
	{
		RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = ~(1 << LayerMask.NameToLayer(_ignoreLayer));

        if(Physics.Raycast(ray, out hit, 1000, mask, QueryTriggerInteraction.Collide))
        {
			var targetDoor = hit.collider.gameObject;
			var blockedItem = targetDoor.GetComponent<BlockedDoorItem>();
			if(blockedItem == null) return false;

			return blockedItem.Unlock(this.gameObject);
            /*gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
			Debug.Log("Collider drop is : " + hit.collider.transform.name);*/
        }

		return false;
	}
}
