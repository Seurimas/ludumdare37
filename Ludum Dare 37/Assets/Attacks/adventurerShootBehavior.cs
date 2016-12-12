using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventurerShootBehavior : AttackBehavior
{
    public int speed;
    public float disengageDistance = 10f;
    public float engageDistance = 7f;
    public float shootDistance = 5f;
    public float interval = 3f;
    private float sinceLast = 0;
    public GameObject projectile;
    private Rigidbody2D rb2d;
    private GameObject target;
    // Use this for initialization
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void shoot(GameObject target)
    {
        Vector2 vectorToTarget = target.transform.position - transform.position;
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Debug.Log(angleToTarget);
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.AngleAxis(angleToTarget - 90, new Vector3(0, 0, 1)));
        missile.GetComponent<Rigidbody2D>().velocity = vectorToTarget.normalized * speed;
    }

    private bool onCooldown()
    {
        return sinceLast < interval;
    }

    public override void engage(AdventurerAttackController me, GameObject target)
    {
        this.target = target;
    }

    public override void update(AdventurerAttackController me)
    {
        float distance = me.mind.distanceToTarget();
        if ((me.mind.state == AdventurerStateController.STATE.ATTACKING || me.mind.state == AdventurerStateController.STATE.APPROACHING) &&
                distance > disengageDistance)
        {
            me.mind.disengage();
        }
        else if (onCooldown())
        {
            sinceLast += Time.deltaTime;
            me.legs.stop();
            rb2d.velocity.Set(0, 0);
        }
        else
        {
            if (me.mind.state == AdventurerStateController.STATE.ATTACKING)
            {
                if (distance < shootDistance)
                {
                    shoot(target);
                    sinceLast = 0;
                }
                else
                {
                    me.legs.advanceTowards(target.transform.position);
                }
            }
        }
    }

    public override float getAttackDistance(AdventurerAttackController me)
    {
        return engageDistance;
    }
}

