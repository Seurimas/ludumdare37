using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public List<Waypoint> adjacentWaypoints;
    private Dictionary<Waypoint, Waypoint> transitionWaypoint = new Dictionary<Waypoint, Waypoint>();
	// Use this for initialization
	void Start () {
        calculatePaths();
	}

    private void calculatePaths()
    {
        List<Waypoint> unvisited = new List<Waypoint>();
        unvisited.AddRange(adjacentWaypoints);
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
        return transitionWaypoint[target];
    }

    // Update is called once per frame
    void Update () {
		
	}
}
