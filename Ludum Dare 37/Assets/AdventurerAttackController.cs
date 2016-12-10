using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerAttackController : MonoBehaviour {
    private AdventurerStateController mind;
    private AdventurerMovementController legs;
    private GameObject target;
    public float attackDistance = 2;
	// Use this for initialization
	void Start () {
        mind = GetComponent<AdventurerStateController>();
        legs = GetComponent<AdventurerMovementController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mind.state == AdventurerStateController.STATE.ATTACKING)
        {
            legs.advanceTowards(target.transform.position);
        }
	}

    public void engage(GameObject aggro)
    {
        target = aggro;
    }
}
