using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ActionItemBase : MonoBehaviour, IActionItem
{
	public abstract void Execute();
}
