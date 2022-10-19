using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (transform.childCount == 0)
        {
            draggableItem.afterDragParent = transform;   
        }


        if (transform.childCount == 1 && transform.GetChild(0).gameObject.tag != draggableItem.transform.gameObject.tag)
        {
            draggableItem.afterDragParent = transform;
            transform.GetChild(0).parent = draggableItem.beforeDragParent.transform;
        }
        
        if (transform.childCount == 1 && transform.GetChild(0).gameObject.tag == draggableItem.transform.gameObject.tag)
        {
            transform.GetChild(0).gameObject.GetComponent<DraggableItem>().itemCount++;
            Destroy(draggableItem.transform.gameObject);
        }
    }
}
