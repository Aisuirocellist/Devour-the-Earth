using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateObj : MonoBehaviour, IScrollHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private bool mouseOver;
    private DragDrop dragObjScript;
    private Assimilation.ShipData shipData;

    public float rotationSpeed;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        dragObjScript = GetComponent<DragDrop>();
    }

    public void OnScroll(PointerEventData eventData)
    {
        if(shipData == null)
            shipData = dragObjScript.shipData;

        if (dragObjScript.onArea && mouseOver)
        {
            float scrollAmount = eventData.scrollDelta.y;

            Vector3 currentRotation = transform.localEulerAngles;
            currentRotation.z += scrollAmount * rotationSpeed;

            transform.localEulerAngles = currentRotation;
            shipData.minionAngle = rectTransform.rotation;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}
