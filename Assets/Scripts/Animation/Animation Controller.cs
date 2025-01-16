using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private readonly int isRunning = Animator.StringToHash("isRunning");
    private readonly int isHurt = Animator.StringToHash("isHurt");
    private CharacterController CharacterController;
    [SerializeField] private ParticleSystem particleSystem;
    private bool createDust = true;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        CharacterController.onMoveEvent.AddListener(Move);
        CharacterController.onMoveEvent.AddListener(Dust);
        CharacterController.onDamgeEvent.AddListener(Hurt);
    }

    private void Move(Vector2 movement)
    {
        animator.SetBool(isRunning, movement.magnitude > 0.3f); 
    }

    private void Hurt(float damage)
    {
        animator.SetBool(isHurt, true);
    }

    private void ResetHurt()
    {
        animator.SetBool(isHurt, false);
    }

    private void Dust(Vector2 movement)
    {
        if (createDust)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}
