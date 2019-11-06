using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreventClikingGrid : MonoBehaviour,IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler {

	public static bool IsClickingUI { get; private set; }
  
    //private void OnMouseExit()
    //{
    //    IsClickingUI = false;
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.layer == 5)
        IsClickingUI = true;
        Debug.Log("clickui " + eventData.pointerCurrentRaycast.gameObject.layer);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enterui " + eventData.pointerCurrentRaycast.gameObject.layer);

        if (eventData.pointerCurrentRaycast.gameObject.layer == 5)
            IsClickingUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsClickingUI = false;

    }
}
