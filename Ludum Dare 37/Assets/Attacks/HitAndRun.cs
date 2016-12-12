using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndRun : AttackBehavior
{
    public GameObject swingingWeaponPrefab;
    public Sprite sprite;
    public float engageDistance = 3f;
    public float disengageDistance = 7f;
    public float swingSize = 1f;
    public float swingDuration = 0.5f;
    public float damageDealt;
    public float cooldown = 8f;
    private float progress = 0;
    private GameObject target;
    private GameObject swingObject;
    private Rigidbody2D rb2d;
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        progress = cooldown;
    }
    public override void engage(AdventurerAttackController me, GameObject target)
    {
        this.target = target;
    }

    public override float getAttackDistance(AdventurerAttackController me)
    {
        if (onCooldown())
            return 0;
        else
            return engageDistance;
    }

    public override void update(AdventurerAttackController me)
    {
        progress += Time.deltaTime;
        float distance = me.mind.distanceToTarget();
        if ((me.mind.state == AdventurerStateController.STATE.ATTACKING || me.mind.state == AdventurerStateController.STATE.APPROACHING) && 
                (distance > disengageDistance || onCooldown()))
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
                    progress = 0;
                } else
                {
                    me.legs.advanceTowards(target.transform.position);
                }
            }
        }
    }

    private bool onCooldown()
    {
        return progress < cooldown;
    }

    private void swingAt(Transform location, Vector3 angle)
    {
        swingObject = GameObject.Instantiate(swingingWeaponPrefab, location.position, Quaternion.identity, location);
        swingObject.GetComponent<SpriteRenderer>().sprite = sprite;
        swingObject.GetComponent<BoxCollider2D>().size = sprite.bounds.size;
        swingObject.transform.position += new Vector3(0, 1);
        swingObject.GetComponent<SwingingWeapon>().targetAngle = Mathf.Atan2(angle.x, angle.y) * Mathf.Rad2Deg;
        swingObject.GetComponent<SwingingWeapon>().duration = swingDuration;
        damageController damage = swingObject.GetComponent<damageController>();
        if (damage != null)
            damage.damageDealt = damageDealt;
    }
}
