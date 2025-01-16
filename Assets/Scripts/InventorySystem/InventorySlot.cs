using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;
    // at the start deselect all
    private void Awake(){
        Deselect();
    }

    public void Select(){
        image.color = selectedColor;
    }
    public void Deselect(){
        image.color = notSelectedColor;
    }
    //Drag and drop item
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItems inventoryItem = eventData.pointerDrag.GetComponent<InventoryItems>();
            inventoryItem.parentAfterDrag = transform;
        }    
    }
}