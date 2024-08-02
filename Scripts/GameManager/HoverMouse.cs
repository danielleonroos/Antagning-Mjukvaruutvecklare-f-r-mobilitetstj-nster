using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject toolTip;

    void Start()
    {
        toolTip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.SetActive(true);
        Debug.Log("Testing");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.SetActive(false);
    }
}
