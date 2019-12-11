using UnityEngine;

public abstract class GameItemBase : MonoBehaviour, IGameItem
{
    [SerializeField]
    private OutlineItemBase _outlineItem;
	public OutlineItemBase OutlineItem => this.OutlineItem;

	public abstract bool Execute(GameObject obj);

    void OnMouseEnter()
	{
		var renderer = this.gameObject.GetComponent<Renderer>();
		if(renderer != null)
		{
			this._outlineItem.PrevMaterial = renderer.material;
			renderer.material = this._outlineItem.OutlineMaterial;
		}
	}

	void OnMouseExit()
	{
		var renderer = this.gameObject.GetComponent<Renderer>();
		if(renderer != null)
		{
			renderer.material = this._outlineItem.PrevMaterial;
			this._outlineItem.PrevMaterial = null;
		}
	}
}
