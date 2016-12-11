using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Hug", menuName = "Attack/Hug", order = 1)]
public class Hug : ScriptableObject, AttackBehavior
{
    private GameObject target;
    public void engage(AdventurerAttackController me, GameObject target)
    {
        this.target = target;
    }

    public void update(AdventurerAttackController me)
    {
        if (me.mind.state == AdventurerStateController.STATE.ATTACKING)
        {
            me.legs.advanceTowards(target.transform.position);
        }
    }

    public float getAttackDistance(AdventurerAttackController me)
    {
        return 5;
    }
}