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
        ATTACKING,
        HEALING,
        FLANKING
    };
    public STATE state { get; private set; }
    public Waypoint door;
    public Waypoint currentWaypoint;
    private Waypoint targetWaypoint;
    private GameObject aggro;

    public Waypoint loot;
    public float cashoutValue = 2f;
    private float goldEarned = 0;
    private AdventurerMovementController legs;
    // Use this for initialization
    void Start () {
        state = STATE.SPAWNED;
        legs = GetComponent<AdventurerMovementController>();
    }

    internal void OnReachWaypoint(Waypoint reached)
    {
        Debug.Log(String.Format("{0} reached {1}", this, reached));
        currentWaypoint = reached;
        if (reached == targetWaypoint)
        {
            switch (state)
            {

            }
        } else
        {
            move();
        }
    }

    // Update is called once per frame
    void Update () {
		switch (state)
        {
            case STATE.SPAWNED:
                state = STATE.ADVANCING;
                targetWaypoint = loot;
                move();
                break;
            case STATE.LOOTING:
                lootForFrame();
                if (goldEarned > cashoutValue)
                {
                    state = STATE.RETREATING;
                    targetWaypoint = door;
                }
                break;
        }
	}

    private void move()
    {
        legs.moveTo(currentWaypoint.getNextWaypointTo(targetWaypoint));
    }

    internal void initialize(GameObject door, GameObject loot)
    {
        this.door = door.GetComponent<Waypoint>();
        this.loot = loot.GetComponent<Waypoint>();
        currentWaypoint = this.door;
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
                state = STATE.ATTACKING;
                aggro = gameObject;
                break;
        }
    }
}
