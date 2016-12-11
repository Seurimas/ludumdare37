using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerStateController : MonoBehaviour {
    public enum STATE
    {
        SPAWNED,
        ADVANCING,
        LOOTING,
        RETREATING,
        APPROACHING,
        ATTACKING,
        HEALING,
        FLANKING
    };
    public STATE state { get; private set; }
    public Waypoint door;
    private Waypoint targetWaypoint;
    private GameObject aggro;

    public Waypoint loot;
    public float cashoutValue = 2f;
    private float goldEarned = 0;
    private AdventurerMovementController legs;
    private AdventurerAttackController fists;
    // Use this for initialization
    void Start () {
        state = STATE.SPAWNED;
        legs = GetComponent<AdventurerMovementController>();
        fists = GetComponent<AdventurerAttackController>();
    }

    internal void OnReachWaypoint(Waypoint reached)
    {
        if (reached == targetWaypoint)
        {
            switch (state)
            {
                case STATE.ADVANCING:
                    state = STATE.LOOTING;
                    break;
                case STATE.RETREATING:
                    Destroy(this.gameObject);
                    break;
                case STATE.APPROACHING:
                    engage(aggro);
                    break;
            }
        } else
        {
            switch (state)
            {
                case STATE.APPROACHING:
                    approach(aggro);
                    break;
                default:
                    move(targetWaypoint);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        float targetDistance = distanceToTarget();
        switch (state)
        {
            case STATE.SPAWNED:
                state = STATE.ADVANCING;
                move(loot);
                break;
            case STATE.LOOTING:
                LootZone zone = loot.GetComponent<LootZone>();
                lootForFrame(zone);
                if (goldEarned > cashoutValue)
                {
                    state = STATE.RETREATING;
                    move(door);
                } else if (zone.gold == 0)
                {
                    state = STATE.ADVANCING;
                    loot = LootZone.getRandomWithLoot().GetComponent<Waypoint>();
                    move(loot);
                }
                break;
            case STATE.ADVANCING:
            case STATE.RETREATING:
                if (targetDistance < fists.getAttackDistance())
                    engage(aggro);
                break;
            case STATE.APPROACHING:
                if (targetDistance < fists.getAttackDistance())
                {
                    engage(aggro);
                } else
                {
                    approach(aggro);
                }
                break;
            case STATE.ATTACKING:
                if (targetDistance > fists.getAttackDistance() + 1)
                {
                    approach(aggro);
                }
                break;
        }
	}

    private void move(Waypoint targetWaypoint)
    {
        this.targetWaypoint = targetWaypoint;
        Waypoint source = Waypoint.getNearestTo(this.gameObject);
        legs.moveTo(source.getNextWaypointTo(targetWaypoint));
    }

    private void approach(GameObject target)
    {
        state = STATE.APPROACHING;
        move(Waypoint.getNearestTo(target));
    }

    private void engage(GameObject target)
    {
        state = STATE.ATTACKING;
        legs.stop();
        fists.engage(target);
    }

    public void disengage()
    {
        Debug.Log("Disengaging.");
        if (goldEarned > cashoutValue)
        {
            state = STATE.RETREATING;
            move(door);
        } else
        {
            state = STATE.ADVANCING;
            move(loot);
        }
    }

    internal void initialize(GameObject door, GameObject loot)
    {
        this.door = door.GetComponent<Waypoint>();
        this.loot = loot.GetComponent<Waypoint>();
    }

    private void lootForFrame(LootZone zone)
    {
        goldEarned += zone.loot(Time.deltaTime);
    }

    public void aggroPlayer(GameObject gameObject)
    {
        aggro = gameObject;
    }

    public float distanceToTarget()
    {
        if (aggro != null)
            return (aggro.transform.position - transform.position).magnitude;
        else
            return Mathf.Infinity;
    }
}
