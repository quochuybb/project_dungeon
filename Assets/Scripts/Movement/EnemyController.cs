using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : CharacterController
{
    public Transform target;
    public override void Awake()
    {
        base.Awake();
        target = FindObjectByTags();
    }

    public virtual void FixedUpdate()
    {
        target = FindObjectByTags();
    }

    public Transform FindObjectByTags()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public float DistanceToTarget(Transform target)
    {
        return Vector3.Distance(transform.position, target.position);
    }

    public Vector2 DirectionToTarget(Transform target)
    {
        return (target.position - transform.position).normalized;
    }

    public bool CanSeePlayer(Transform target)
    {
        return DistanceToTarget(target) < 100f;
    }
}
