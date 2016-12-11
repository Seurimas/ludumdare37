using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSwing", menuName = "Attack/WeaponSwing", order = 1)]
public class WeaponSwing : ScriptableObject, AttackBehavior
{
    public Sprite sprite;
    public float engageDistance = 3f;
    public float swingSize = 1f;
    public float swingDuration = 0.5f;
    public void engage(AdventurerAttackController me, GameObject target)
    {
        
    }

    public float getAttackDistance(AdventurerAttackController me)
    {
        return engageDistance;
    }

    public void update(AdventurerAttackController me)
    {
        
    }
}
