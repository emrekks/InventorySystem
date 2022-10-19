using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject dropPanel;
    public GameObject draggedItem;

    #region singleton

    public static InventoryManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    
    public void EvetDropPanel()
    {
        Destroy(draggedItem);
        dropPanel.SetActive(false);
    }
    
    public void HayirDropPanel()
    {
        Debug.Log(draggedItem);
        draggedItem.GetComponent<DraggableItem>().BackToOldPosition();
        dropPanel.SetActive(false);
    }
    
}
