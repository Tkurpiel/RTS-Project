using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSelectionHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

	[SerializeField]
		Image selectionBoxImage;

		Vector2 startPoistion;
		Rect selectionRect;



	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!Input.GetKey (KeyCode.LeftControl) && !Input.GetKey (KeyCode.RightControl)) {
			SelectUnits.DeselectAll(new BaseEventData(EventSystem.current));
		}
		selectionBoxImage.gameObject.SetActive (true);
		startPoistion = eventData.position;
		selectionRect = new Rect ();
	}

	public void OnDrag(PointerEventData eventData)
	{
        //Creates an area that all units inside are selected
		if (eventData.position.x < startPoistion.x) {
			selectionRect.xMin = eventData.position.x;
			selectionRect.xMax = startPoistion.x;
		} else {
			selectionRect.xMin = startPoistion.x;
			selectionRect.xMax = eventData.position.x;
		}

		if (eventData.position.y < startPoistion.y) {
			selectionRect.yMin = eventData.position.y;
			selectionRect.yMax = startPoistion.y;
		} else {
			selectionRect.yMin = startPoistion.y;
			selectionRect.yMax = eventData.position.y;
		}

		selectionBoxImage.rectTransform.offsetMin = selectionRect.min;
		selectionBoxImage.rectTransform.offsetMax = selectionRect.max;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
        //Turns all units in drag to isSelected
		selectionBoxImage.gameObject.SetActive (false);
		foreach (SelectUnits selectable in SelectUnits.allSelectUnits) {
			if (selectionRect.Contains (Camera.main.WorldToScreenPoint (selectable.transform.position))) {
				selectable.OnSelect (eventData);
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		List<RaycastResult> results = new List<RaycastResult> ();
		EventSystem.current.RaycastAll (eventData, results);

		float myDistance = 0;

		foreach (RaycastResult result in results) {
			if (result.gameObject == gameObject) {
				myDistance = result.distance;
				break;
			}
		}
		GameObject nextObject = null;
		float maxDistance = Mathf.Infinity;
		foreach (RaycastResult result in results) {
			if (result.distance > myDistance && result.distance < maxDistance) {
				nextObject = result.gameObject;
				maxDistance = result.distance;
			}
		}
		if (nextObject) {
			ExecuteEvents.Execute<IPointerClickHandler>(nextObject, eventData, (x, y) => { x.OnPointerClick((PointerEventData)y); });
		}
	}
}
