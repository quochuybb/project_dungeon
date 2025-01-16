using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bomb", menuName = "Bomb")]
public class BombConfig : ScriptableObject
{
    public float damage;
    public float force;
    public float fieldImpact;
    public float throwForce;
    public float countdown;


}
