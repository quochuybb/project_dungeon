 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    int selectedSlot = -1;
    private void Update(){
        //check if any key is pressed
        if(Input.inputString != null){
            //check if key is a number
            bool isNumber = int.TryParse(Input.inputString, out int number);
            //if number in range of hot bar change selected slot
            if(isNumber && number >0 && number <6){
                ChangeSelectedSlot(number - 1);
            }
        }
    }
    void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        // loop through all the slots to find an empty slot
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItems itemInSlot = slot.GetComponentInChildren<InventoryItems>();

            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }

            if(itemInSlot != null && itemInSlot.item == item && itemInSlot.count <4 && item.isStackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        return false;
    }

    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        // create new item on the scene
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItems inventoryItems = newItemGo.GetComponent<InventoryItems>();
        inventoryItems.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItems itemInSlot = slot.GetComponentInChildren<InventoryItems>();
        if(itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if(use == true){
                itemInSlot.count--;
                itemInSlot.RefreshCount();
                if(itemInSlot.count == 0){
                    Destroy(itemInSlot.gameObject);
                }
            }
            return item;
        }
        return null;
    }
}
