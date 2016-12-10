using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerMovementController : MonoBehaviour {
    public float speed = 10f;
    private AdventurerStateController mind;
    private Vector3? targetPosition;
    private Waypoint nextWaypoint;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        mind = GetComponent<AdventurerStateController>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (targetPosition != null)
        {
            Vector3 vector = (targetPosition.Value - transform.position);
            if (vector.magnitude < speed * Time.deltaTime)
            {
                targetPosition = null;
                if (nextWaypoint != null)
                    mind.OnReachWaypoint(nextWaypoint);
            }
            else
            {
                Vector2 movement = vector.normalized * (speed * Time.deltaTime);
                rb2d.MovePosition(rb2d.position + movement);
            }
        }
	}

    internal void advanceTowards(Vector3 position)
    {
        Debug.Log(String.Format("Advancing towards {0}", position));
        targetPosition = position;
        nextWaypoint = null;
    }

    public void moveTo(Waypoint target)
    {
        targetPosition = target.transform.position;
        nextWaypoint = target;
    }

    public void stop()
    {
        targetPosition = null;
    }
}
