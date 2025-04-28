//using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    private Transform gridobject;
    public enum DropSpace { shipArea, menuArea }
    public DropSpace droparea;

    private void Awake()
    {
        if (droparea == DropSpace.menuArea) {
            gridobject = this.transform.Find("Viewport").Find("Content");
        }
    }
    public void OnDrop(PointerEventData eventData)
    {

        GameObject dropObj = eventData.pointerDrag;

        if (dropObj.GetComponent<DragDrop>() == null)
            return;

        DragDrop itemScript = dropObj.GetComponent<DragDrop>();
        Assimilation.ShipData shipData = itemScript.shipData;
        //Debug.Log("OnDrop");

        if (eventData.pointerDrag != null) {

            switch (droparea)
            {
                case DropSpace.shipArea:
                    if (!itemScript.overlap)
                    {
                        if (!itemScript.onArea)
                            Assimilation.swapToMinionList(shipData);

                        itemScript.onArea = true;
                        itemScript.CanRotate(true);
                        itemScript.home = dropObj.GetComponent<RectTransform>().anchoredPosition;
                        shipData.hubLocation = itemScript.home;
                        shipData.gameLocation = itemScript.hubToGameLocation();
                        //Debug.Log("Shiparea");
                    }
                    break;

                case DropSpace.menuArea:

                    if (itemScript.onArea)
                        Assimilation.swapToCollectionList(shipData);

                    dropObj.transform.SetParent(gridobject);
                    itemScript.onArea = false;
                    itemScript.CanRotate(false);
                    //Debug.Log("menuarea");
                    break;
            
            }
        }
    }
}
