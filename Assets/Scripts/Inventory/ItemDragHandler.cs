using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
	public IInventoryItem Item { get; set; }
	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.localPosition = Vector3.zero;
	}
}
