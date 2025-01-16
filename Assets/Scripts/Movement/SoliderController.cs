using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderController : EnemyController
{
    public override void FixedUpdate()
    {
        lastTimeAttack += Time.fixedDeltaTime;
        target = FindObjectByTags();
        if (CanSeePlayer(target))
        {

            if (DistanceToTarget(target) < 7f)
            {
                if (lastTimeAttack >= bulletConfig.delay)
                {
                    lastTimeAttack = 0f;
                    useGun = true;
                    onLookEvent.Invoke(DirectionToTarget(target));
                }
                else
                {
                    onLookEvent.Invoke(DirectionToTarget(target));
                }
            } 
            else
            {
                onLookEvent.Invoke(DirectionToTarget(target));
                onMoveEvent.Invoke(DirectionToTarget(target) * 0.5f);
            }
        }
    }
    
}
