using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable objects/Item")]
public class Item : ScriptableObject
{
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public float buff;
    public bool isStackable = true;
    public Sprite image;
}

public enum ItemType
{
    weapon,
    equipment,
    consumable
}
public enum ActionType
{
    attack,
    health,
    upgrade
}