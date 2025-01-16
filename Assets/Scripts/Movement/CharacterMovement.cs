using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private CharacterController characterController;
    private float speed = 5;
    private bool canDash = true;
    private bool isDashing;
    private float dashDuration = 1f;
    private float dashPower = 1f;
    private float dashCooldown = 5f;
    [SerializeField] private TrailRenderer dashTrail;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        ApplyMovement(movement);
    }

    private void Start()
    {
        characterController.onMoveEvent.AddListener(OnMove);
        characterController.onDash.AddListener(Dashing);
    }

    private void OnMove(Vector2 movement)
    {
        this.movement = movement;
    }

    private void ApplyMovement(Vector2 movement)
    {
        rb.velocity = movement * speed;
    }

    private void Dashing()
    {
        if (canDash)
        {
            canDash = false;
            isDashing = true; 
            rb.AddForce(movement * dashPower, ForceMode2D.Force);
            dashTrail.emitting = true;
        }
        dashTrail.emitting = false;
        isDashing = false;
        canDash = true;
    }
}

