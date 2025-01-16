using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private BombConfig config;
    private CharacterController controller;
    private Vector2 direction;
    private bool animate = false;
    [SerializeField] private Rigidbody2D rb2d;
    private bool isThrown = false;
    public void InitBomb(BombConfig bombConfig, Vector2 direction)
    {
        this.config = bombConfig;
        this.direction = direction;
        isThrown = true;
    }
    private void Update()
    {
        if (!isThrown)
        {
            return;
        }
        Debug.Log(this.direction);
        rb2d.velocity = direction * config.throwForce;
    }

    private void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, config.fieldImpact, layerMask);
        foreach (Collider2D obj in objects)
        {
            Vector2 impact = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(impact * config.force);
        }
        CreateParticleSystem();
    }
    private void CreateParticleSystem()
    {
        particleSystem.transform.position = gameObject.transform.position;
        particleSystem.Stop();
        particleSystem.Play();

    }

    public void OnExplosion()
    {
        if (animate)
        {
            Explode();
        }
        gameObject.SetActive(false);
    }
}
