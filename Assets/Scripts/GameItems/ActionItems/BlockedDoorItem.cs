using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockedDoorItem : SwitchLocationActionItem
{
    private bool IsUnlock = false;
    private string DoorBlockedStr = "Дверь закрыта, необходимо найти ключ";
    
    [SerializeField]
    private GameObject _Unlocker;

    public override void OnPointerClick(PointerEventData eventData)
	{
        if(IsUnlock)
        {
            Execute();
        }
        else {
            MindImage.gameObject.SetActive(false);
		    TextMind.text = "";
            StartCoroutine(ShowDoorMessage(DoorBlockedStr));
        }
	}

    public bool Unlock(GameObject key)
    {
        IsUnlock = key == _Unlocker;
        return IsUnlock;
    }

    public override void OnPointerEnter(PointerEventData eventData)
	{
        Debug.Log("Overrided pointer enter");

        if(IsUnlock)
        {
		    StartCoroutine(ShowDoorMessage(Description));
        }
        else 
        {
            StartCoroutine(ShowDoorMessage(DoorBlockedStr));
        }
	}
}
