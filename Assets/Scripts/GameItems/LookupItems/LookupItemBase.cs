using UnityEngine;
using UnityEngine.EventSystems;

public class LookupItemBase : MonoBehaviour, ILookupItem
{
    [SerializeField]
    private Camera CameraToFocus;

	[SerializeField]
	private Camera CameraToHide;

	[SerializeField]
	private GameManager GameManager;

    private Vector3 _prevCameraPosition;
    private Quaternion _prevCameraRotation;

	public void Lookup()
	{
		GameManager.IsPaused = true;
		
        CameraToHide.gameObject.SetActive(false);
		CameraToFocus.gameObject.SetActive(true);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
        Debug.Log("OnPointer lookup");
		this.Lookup();
	}

	public void UnFocus()
	{
		CameraToFocus.gameObject.SetActive(false);
		CameraToHide.gameObject.SetActive(true);

		GameManager.IsPaused = false;
	}
}
