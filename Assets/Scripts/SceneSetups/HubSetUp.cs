using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HubSetUp : MonoBehaviour
{
    [SerializeField] private GameObject StickerPrefab;
    public Transform grid;
    public Canvas canvas;
    public GameObject centerObj;

    private GameObject sticker;
    private RectTransform rectTransform;
    private DragDrop dragScript;
    void Start()
    {
        foreach (Assimilation.ShipData shipdata in Assimilation.collectionList)
        {
            sticker = Instantiate(StickerPrefab);
            rectTransform = sticker.GetComponent<RectTransform>();
            dragScript = sticker.GetComponent<DragDrop>();
            dragScript.shipData = shipdata;
            dragScript.hub = this;

            sticker.GetComponentInChildren<UnityEngine.UI.Image>().sprite = shipdata.stickerSprite;
            sticker.transform.SetParent(grid);
            rectTransform.localScale = new Vector2(2, 2);
        }
        foreach (Assimilation.ShipData shipdata in Assimilation.minionList)
        {
            sticker = Instantiate(StickerPrefab);
            rectTransform = sticker.GetComponent<RectTransform>();
            dragScript = sticker.GetComponent<DragDrop>();

            dragScript.shipData = shipdata;
            dragScript.hub = this;
            dragScript.onArea = true;

            sticker.GetComponentInChildren<UnityEngine.UI.Image>().sprite = shipdata.stickerSprite;
            sticker.transform.SetParent(canvas.transform, true);
            rectTransform.localScale = new Vector2(2, 2);

            rectTransform.anchorMax = new Vector2(0, 1);
            rectTransform.anchorMin = new Vector2(0, 1);
            rectTransform.anchoredPosition = shipdata.hubLocation;
            rectTransform.rotation = shipdata.minionAngle;
        }

        //GameObject sticker = Instantiate(StickerPrefab);
        //sticker.transform.SetParent(canvas.transform, true);
        //sticker.GetComponent<RectTransform>().localScale = new Vector2(2, 2);
        ////sticker.GetComponentInChildren<UnityEngine.UI.Image>().sprite = shipType.GetComponent<SpriteRenderer>().sprite;
        //sticker.GetComponentInChildren<UnityEngine.UI.Image>().sprite = shipType.GetComponentInChildren<SpriteRenderer>().sprite;

        //if (active)
        //{
        //    //Debug.Log("Hello");
        //    sticker.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        //    sticker.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        //    sticker.GetComponent<RectTransform>().anchoredPosition = GetComponent<MinionData>().hubLocation;
        //    sticker.GetComponent<RectTransform>().rotation = minionAngle;
        //}
        //else
        //{
        //    sticker.transform.SetParent(grid);
        //}
        //transform.SetParent(sticker.transform);
        //this.transform.localPosition = Vector2.zero;
    }
}
