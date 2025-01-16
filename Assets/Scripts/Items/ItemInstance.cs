using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemData itemData;     // Reference to the static data
    public int currentAmount;     // Current quantity or ammo for the item

    // Constructor
    public ItemInstance(ItemData data, int initialAmount = -1)
    {
        itemData = data;
        // If an initial amount is provided, use it; otherwise, default to the starting amount from ItemData
        currentAmount = initialAmount >= 0 ? initialAmount : itemData.startingAmmount;
    }
}