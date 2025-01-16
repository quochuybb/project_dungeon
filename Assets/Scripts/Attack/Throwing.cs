using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 aimDirection = Vector2.right;
    private BombManager bombManager;
    [SerializeField] private BombConfig bombConfig;
    [SerializeField] private Transform throwPoint;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        bombManager = BombManager.instance;
        controller.onLookEvent.AddListener(OnLookMouseThrow);
        controller.onThrow.AddListener(OnThrowingItem);
    }
    private void OnThrowingItem( )
    {
        bombManager.ThrowBomb(throwPoint.position, bombConfig, aimDirection);
    }
    private void OnLookMouseThrow(Vector2 aimDirection)
    {
        this.aimDirection = aimDirection;
    }
}
