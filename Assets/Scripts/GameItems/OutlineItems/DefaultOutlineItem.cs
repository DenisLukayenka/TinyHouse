using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultOutlineItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private DefaultOutlineScriptObject _outlineScriptObject;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("POinter in");
        var renderer = this.gameObject.GetComponent<Renderer>();
		if(renderer != null)
		{
			this._outlineScriptObject.PrevMaterial = renderer.material;
			renderer.material = this._outlineScriptObject.OutlineMaterial;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Pointer out");
		var renderer = this.gameObject.GetComponent<Renderer>();
		if(renderer != null)
		{
			renderer.material = this._outlineScriptObject.PrevMaterial;
			this._outlineScriptObject.PrevMaterial = null;
		}
	}
}
