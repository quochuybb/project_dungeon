using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;       // Name of the item
    public Sprite icon;           // Icon for the item
    public string description;    // Description of the item
    public int startingAmmount;   // Starting ammount/ammo of the item
    public bool isStackable;      // Can this item be stacked?
}