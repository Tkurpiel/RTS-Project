using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SelectUnits : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler {
	
	public static HashSet<SelectUnits> allSelectUnits = new HashSet<SelectUnits> ();
	public static HashSet<SelectUnits> currentlySelected = new HashSet<SelectUnits> ();

	Renderer myRenderer;
	[SerializeField]
	Material unselectedMaterial;
	[SerializeField]
	Material selectedMaterial;

	public bool isSelected;

	void Awake ()
	{
		allSelectUnits.Add (this);
		myRenderer = GetComponent<Renderer> ();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
        //quickly turns all units off isSelected
		if (!Input.GetKey (KeyCode.LeftControl) && !Input.GetKey (KeyCode.RightControl)) {
			DeselectAll (eventData);
		}
		OnSelect (eventData);
	}

	public void OnSelect(BaseEventData eventData)
	{
        //whenever drag handler hovers over unit set them to isSelected
		currentlySelected.Add (this);
		myRenderer.material = selectedMaterial;
		isSelected = true;

	}

	public void OnDeselect(BaseEventData eventData)
	{
        //when ever a new drag does not have a unit takes them off isSelected
		myRenderer.material = unselectedMaterial;
		isSelected = false;
	}

	public static void DeselectAll (BaseEventData eventData)
	{
		foreach (SelectUnits selectable in currentlySelected) {
			selectable.OnDeselect (eventData);
		}
		currentlySelected.Clear ();
	}
}
