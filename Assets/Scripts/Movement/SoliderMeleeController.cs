using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMeleeController : EnemyController
{
    public override void FixedUpdate()
    {
        lastTimeAttack += Time.fixedDeltaTime;
        target = FindObjectByTags();
        if (CanSeePlayer(target))
        {

            if (DistanceToTarget(target) < 3f)
            {
                if (lastTimeAttack >= meleeConfig.delay)
                {
                    lastTimeAttack = 0f;
                    useMelee = true;
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

