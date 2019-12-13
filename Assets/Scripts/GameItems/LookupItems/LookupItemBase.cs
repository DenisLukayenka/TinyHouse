using UnityEngine;
using UnityEngine.EventSystems;

public class LookupItemBase : MonoBehaviour, ILookupItem
{
    [SerializeField]
    private GameObject FocusPoint;

    private Vector3 _prevCameraPosition;
    private Quaternion _prevCameraRotation;

	public void Lookup()
	{
        this._prevCameraPosition = Camera.main.transform.position;
        this._prevCameraRotation = Camera.main.transform.rotation;

        Camera.main.transform.position = FocusPoint.transform.position;
        Camera.main.transform.rotation = FocusPoint.transform.rotation;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
        Debug.Log("OnPointer");
		this.Lookup();
	}

	public void UnFocus()
	{
		throw new System.NotImplementedException();
	}
}
