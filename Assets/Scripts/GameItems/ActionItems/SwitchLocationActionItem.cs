using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchLocationActionItem : ActionItemBase, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private GameObject _targetLocation;

    [SerializeField]
    private GameObject _currentLocation;

    [SerializeField]
	private string _Description;
	public string Description => this._Description;

	[SerializeField]
	private Image MindImage;

	[SerializeField]
	private TMP_Text TextMind;

	public override void Execute()
	{
		MindImage.gameObject.SetActive(false);
		TextMind.text = "";
		
        _currentLocation.SetActive(false);
        _targetLocation.SetActive(true);
	}

    public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log(MindImage);
		Debug.Log(TextMind);
		Debug.Log(Description);

		MindImage.gameObject.SetActive(true);
		TextMind.text = Description;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		MindImage.gameObject.SetActive(false);
		TextMind.text = "";
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Execute();
	}
}
