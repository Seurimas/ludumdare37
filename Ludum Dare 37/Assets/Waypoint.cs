﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public bool fudgeable = true;
    public List<Waypoint> adjacentWaypoints;
    private Dictionary<Waypoint, Waypoint> transitionWaypoint = new Dictionary<Waypoint, Waypoint>();
	// Use this for initialization
	void Awake () {
        calculatePaths();
	}

    private void calculatePaths()
    {
        List<Waypoint> unvisited = new List<Waypoint>();
        unvisited.AddRange(adjacentWaypoints);
        transitionWaypoint[this] = this;
        foreach (Waypoint near in adjacentWaypoints)
        {
            transitionWaypoint[near] = near;
        }
        while (unvisited.Count > 0)
        {
            List<Waypoint> nextPaths = new List<Waypoint>(unvisited);
            foreach (Waypoint next in nextPaths)
            {
                explore(next, unvisited, transitionWaypoint);
            }
        }
    }

    private void explore(Waypoint next, List<Waypoint> unvisited, Dictionary<Waypoint, Waypoint> paths)
    {
        foreach (Waypoint followed in next.adjacentWaypoints)
        {
            if (!paths.ContainsKey(followed))
            {
                paths[followed] = paths[next];
                unvisited.Add(followed);
            }
        }
        unvisited.Remove(next);
    }

    public Waypoint getNextWaypointTo(Waypoint target)
    {
        if (!transitionWaypoint.ContainsKey(target))
        {
            Debug.Log(this);
            Debug.Log(target);
            Debug.Log(transitionWaypoint);
            return this;
        } else
        {
            return transitionWaypoint[target];
        }
    }

    public void OnDrawGizmos()
    {
        foreach (Waypoint other in adjacentWaypoints)
        {
            Gizmos.DrawLine(transform.position, other.transform.position);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public static Waypoint getNearestTo(GameObject target)
    {
        Waypoint nearest = null;
        float minSqrMag = 100000;
        foreach (Waypoint waypoint in GameObject.FindObjectsOfType<Waypoint>())
        {
            if (target == null)
                return waypoint;
            float sqrMag = (target.transform.position - waypoint.transform.position).sqrMagnitude;
            if (sqrMag < minSqrMag) {
                minSqrMag = sqrMag;
                nearest = waypoint;
            }
        }
        return nearest;
    }
}
