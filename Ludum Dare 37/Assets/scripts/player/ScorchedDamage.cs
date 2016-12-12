using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchedDamage : MonoBehaviour {
    public float dps;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        healthController health = other.GetComponent<healthController>();
        if (health != null)
        {
            if (TeamController.areDifferentTeam(gameObject, other.gameObject))
            {
                health.health -= dps * Time.deltaTime;
            }
        }
    }
}
