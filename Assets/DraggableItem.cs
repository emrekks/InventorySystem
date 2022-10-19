using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [HideInInspector] public Transform afterDragParent;
    
    [HideInInspector] public Transform beforeDragParent;
    
    public int itemCount = 1;
    
    public int indexNumber;
    
    public Image image;

    private bool _holdingShift = false;

    public GameObject thisObj;
    
    #region singleton

    public static DraggableItem instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Start()
    {
        thisObj = this.gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _holdingShift = true;
            Debug.Log(_holdingShift);
        }
    }
  
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_holdingShift)
        {
            Instantiate(thisObj);
        }

        else
        {
            beforeDragParent = transform.parent;
        
            afterDragParent = transform.parent;
       
            transform.SetParent(transform.root);
       
            transform.SetAsLastSibling();
        
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "DropPanel")
        {
            InventoryManager.instance.draggedItem = this.gameObject;
            InventoryManager.instance.dropPanel.SetActive(true);
            Debug.Log(this.gameObject);
        }

        if (!InventoryManager.instance.dropPanel.activeInHierarchy)
        {
            BackToOldPosition();
        }
        
        _holdingShift = false;
    }

    public void BackToOldPosition()
    {
        transform.SetParent(afterDragParent);
        
        image.raycastTarget = true;
    }
    
}
