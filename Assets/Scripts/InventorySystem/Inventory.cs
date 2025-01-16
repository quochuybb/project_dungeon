using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemInstance> items = new List<ItemInstance>();  // List of items in the inventory
    public int maxCapacity = 10;                                // Maximum number of items

    // Add an item to the inventory
    public bool AddItem(ItemData itemData, int amount = -1)
    {
        // Determine the amount to add
        int quantityToAdd = amount >= 0 ? amount : itemData.startingAmmount;

        // Check if the item is stackable and already exists in the inventory
        if (itemData.isStackable)
        {
            ItemInstance existingItem = items.Find(i => i.itemData == itemData);
            if (existingItem != null)
            {
                
                existingItem.currentAmount += quantityToAdd;
                return true;
            }
        }

        // If not stackable or no existing stack, add a new item instance
        if (items.Count < maxCapacity)
        {
            items.Add(new ItemInstance(itemData, quantityToAdd));
            return true;
        }

        Debug.Log("Inventory is full!");
        return false;
    }

    // Remove an item from the inventory
    public void RemoveItem(ItemData itemData, int amount = 1)
    {
        ItemInstance existingItem = items.Find(i => i.itemData == itemData);
        if (existingItem != null)
        {
            existingItem.currentAmount -= amount;
            if (existingItem.currentAmount <= 0)
            {
                items.Remove(existingItem);
            }
        }
    }

    // Check if the inventory contains an item
    public bool ContainsItem(ItemData itemData)
    {
        return items.Exists(i => i.itemData == itemData);
    }

    // Get the quantity of a specific item in the inventory
    public int GetItemQuantity(ItemData itemData)
    {
        ItemInstance existingItem = items.Find(i => i.itemData == itemData);
        return existingItem != null ? existingItem.currentAmount : 0;
    }
}
