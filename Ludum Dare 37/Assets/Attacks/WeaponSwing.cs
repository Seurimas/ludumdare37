using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwing : AttackBehavior
{
    public GameObject swingingWeaponPrefab;
    public Sprite sprite;
    public float engageDistance = 3f;
    public float disengageDistance = 7f;
    public float swingSize = 1f;
    public float swingDuration = 0.5f;
    private GameObject target;
    private GameObject swingObject;
    private Rigidbody2D rb2d;
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public override void engage(AdventurerAttackController me, GameObject target)
    {
        this.target = target;
    }

    public override float getAttackDistance(AdventurerAttackController me)
    {
        return engageDistance;
    }

    public override void update(AdventurerAttackController me)
    {
        float distance = me.mind.distanceToTarget();
        if ((me.mind.state == AdventurerStateController.STATE.ATTACKING || me.mind.state == AdventurerStateController.STATE.APPROACHING) && 
                distance > disengageDistance)
        {
            me.mind.disengage();
        }
        else if (swingObject != null && swingObject.activeInHierarchy)
        {
            me.legs.stop();
            rb2d.velocity.Set(0, 0);
        }
        else
        {
            if (me.mind.state == AdventurerStateController.STATE.ATTACKING)
            {
                if (distance < swingSize)
                {
                    swingAt(me.transform, (target.transform.position - me.transform.position));
                } else
                {
                    me.legs.advanceTowards(target.transform.position);
                }
            }
        }
    }

    private void swingAt(Transform location, Vector3 angle)
    {
        swingObject = GameObject.Instantiate(swingingWeaponPrefab, location.position, Quaternion.identity, location);
        swingObject.GetComponent<SpriteRenderer>().sprite = sprite;
        swingObject.GetComponent<BoxCollider2D>().size = sprite.bounds.size;
        swingObject.transform.position += new Vector3(0, 1);
        swingObject.GetComponent<SwingingWeapon>().targetAngle = Mathf.Atan2(angle.x, angle.y) * Mathf.Rad2Deg;
        swingObject.GetComponent<SwingingWeapon>().duration = swingDuration;
    }
}
