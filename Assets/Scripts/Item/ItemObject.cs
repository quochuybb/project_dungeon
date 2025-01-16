using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Rigidbody2D rigidbody2D;
    [SerializeField] public Item item;
    private void Awake()
    {
        spriteRenderer.sprite = item.image;
    }


}
