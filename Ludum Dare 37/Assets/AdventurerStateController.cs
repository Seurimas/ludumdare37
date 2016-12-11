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
        Debug.Log(String.Format("{0} reached {1}", this, reached));
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
		switch (state)
        {
            case STATE.SPAWNED:
                state = STATE.ADVANCING;
                move(loot);
                break;
            case STATE.LOOTING:
                lootForFrame();
                if (goldEarned > cashoutValue)
                {
                    Debug.Log("Done", this);
                    state = STATE.RETREATING;
                    move(door);
                }
                break;
            case STATE.APPROACHING:
                if (distanceToTarget() < fists.attackDistance)
                {
                    Debug.Log("Engaging!");
                    engage(aggro);
                }
                break;
            case STATE.ATTACKING:
                if (distanceToTarget() > fists.attackDistance + 1)
                {
                    Debug.Log("Approaching!");
                    approach(aggro);
                }
                break;
        }
	}

    private void move(Waypoint targetWaypoint)
    {
        this.targetWaypoint = targetWaypoint;
        legs.moveTo(Waypoint.getNearestTo(this.gameObject).getNextWaypointTo(targetWaypoint));
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

    internal void initialize(GameObject door, GameObject loot)
    {
        this.door = door.GetComponent<Waypoint>();
        this.loot = loot.GetComponent<Waypoint>();
    }

    private void lootForFrame()
    {
        goldEarned += Time.deltaTime;
    }

    public void aggroPlayer(GameObject gameObject)
    {
        switch (state)
        {
            case STATE.SPAWNED:
            case STATE.ADVANCING:
            case STATE.LOOTING:
                aggro = gameObject;
                if (distanceToTarget() > fists.attackDistance)
                    approach(aggro);
                else
                    engage(aggro);
                break;
        }
    }

    public float distanceToTarget()
    {
        return (aggro.transform.position - transform.position).magnitude;
    }
}
