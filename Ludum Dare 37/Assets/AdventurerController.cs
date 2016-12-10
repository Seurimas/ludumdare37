using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour {
    private enum STATE
    {
        SPAWNED,
        ADVANCING,
        LOOTING,
        RETREATING,
        ATTACKING,
        HEALING,
        FLANKING
    };
    private STATE state;
    public Waypoint door;
    public Waypoint currentWaypoint;
    private Waypoint targetWaypoint;
    private GameObject target;

    public Waypoint loot;
    public float cashoutValue = 2f;
    private float goldEarned = 0;
	// Use this for initialization
	void Start () {
        state = STATE.SPAWNED;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state)
        {
            case STATE.SPAWNED:
                state = STATE.ADVANCING;
                targetWaypoint = loot;
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

    internal void initialize(GameObject door, GameObject loot)
    {
        this.door = door.GetComponent<Waypoint>();
        currentWaypoint = this.door;
        targetWaypoint = loot.GetComponent<Waypoint>();
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
                target = gameObject;
                break;
        }
    }
}
