using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,
    IDragHandler
{
    [SerializeField] private Camera cam;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private RotateObj roateScript;
    private bool mouseOver;
    public Assimilation.ShipData shipData;
    public bool overlap;

    public Vector2 home;
    public bool onArea;

    public HubSetUp hub;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        roateScript = GetComponent<RotateObj>();
        cam = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(hub.canvas.transform, true);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, cam, out globalMousePos))
        {
            rectTransform.position = globalMousePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GetComponent<DragDrop>() == null)
            return;

        //Debug.Log("OnEndDrag");
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<DropArea>() == null || overlap)
        {
            if (onArea)
            {

                //Debug.Log("AAA");
                rectTransform.anchoredPosition = home;
                shipData.hubLocation = home;
                shipData.gameLocation = hubToGameLocation();
            }
            else
            {
                //Debug.Log("AAAA");
                CanRotate(false);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                Transform gridObject = hub.grid;
                this.transform.SetParent(gridObject);
            }
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void CanRotate(bool rotateable)
    {
        if (rotateable)
            roateScript.enabled = true;
        else
            roateScript.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter");
        if (other.CompareTag("StickerOverlap") || other.CompareTag("Sticker"))
        {
            overlap = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exit");
        if (other.CompareTag("StickerOverlap") || other.CompareTag("Sticker"))
        {
            overlap = false;
        }
    }

    public Vector2 hubToGameLocation()
    {
        GameObject ship = hub.centerObj;
        Vector2 midpoint = ship.GetComponent<RectTransform>().TransformPoint(ship.GetComponent<RectTransform>().rect.center);
        Vector2 minionPoint = rectTransform.TransformPoint(rectTransform.rect.center);

        //Debug.Log(midpoint);

        Vector2 offset = minionPoint - midpoint;
        //Debug.Log(offset);
        return offset;
    }
}