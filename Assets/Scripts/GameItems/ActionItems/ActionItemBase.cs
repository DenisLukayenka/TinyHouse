using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public abstract class ActionItemBase : MonoBehaviour, IActionItem
{
	public abstract void Execute();
}
