using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerMovementController : MonoBehaviour {
    public float speed = 10f;
    private AdventurerStateController mind;
    public Vector3? targetPosition;
    public Waypoint nextWaypoint;
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
            if (vector.magnitude < 1f)
            {
                targetPosition = null;
                if (nextWaypoint != null)
                    mind.OnReachWaypoint(nextWaypoint);
            }
            else
            {
                Vector2 movement = vector.normalized * (speed);
                rb2d.velocity = movement;
                if (mind.state == AdventurerStateController.STATE.RETREATING)
                    rb2d.mass = 10;
                else
                    rb2d.mass = 1;
            }
        } else
        {
            rb2d.velocity.Set(0, 0);
        }
	}

    internal void advanceTowards(Vector3 position)
    {
        targetPosition = position;
        nextWaypoint = null;
    }

    public void moveTo(Waypoint target)
    {
        targetPosition = target.transform.position;
        if (target.fudgeable)
            targetPosition += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        nextWaypoint = target;
    }

    public void stop()
    {
        targetPosition = null;
    }

    public void OnDrawGizmos()
    {
        if (targetPosition != null)
            Gizmos.DrawLine(transform.position, targetPosition.Value);
    }
}
