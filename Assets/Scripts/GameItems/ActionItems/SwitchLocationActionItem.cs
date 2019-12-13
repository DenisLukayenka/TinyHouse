using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchLocationActionItem : ActionItemBase, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private GameObject _targetLocation;

    [SerializeField]
    private GameObject _currentLocation;

    [SerializeField]
	private string _Description;
	public string Description => this._Description;

	[SerializeField]
	protected Image MindImage;

	[SerializeField]
	protected TMP_Text TextMind;

	public override void Execute()
	{
		MindImage.gameObject.SetActive(false);
		TextMind.text = "";

        _currentLocation.SetActive(false);
        _targetLocation.SetActive(true);
	}

    public virtual void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Default pointer enter");
		StartCoroutine(ShowDoorMessage(Description));
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		Execute();
	}

	public IEnumerator ShowDoorMessage(string message)
    {
        Debug.Log("Coroutine started");

        MindImage.gameObject.SetActive(true);
		TextMind.text = message;

        yield return new WaitForSeconds(5);

        MindImage.gameObject.SetActive(false);
		TextMind.text = "";
    }
}
