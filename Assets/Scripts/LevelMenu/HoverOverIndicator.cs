using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverIndicator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject indicator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        indicator.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        indicator.SetActive(false);
    }
}
