using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class Hug : AttackBehavior
{
    private GameObject target;
    public override void engage(AdventurerAttackController me, GameObject target)
    {
        this.target = target;
    }

    public override void update(AdventurerAttackController me)
    {
        if (me.mind.state == AdventurerStateController.STATE.ATTACKING)
        {
            me.legs.advanceTowards(target.transform.position);
        }
    }

    public override float getAttackDistance(AdventurerAttackController me)
    {
        return 5;
    }
}