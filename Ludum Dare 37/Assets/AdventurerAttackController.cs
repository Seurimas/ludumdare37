using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AdventurerAttackController : MonoBehaviour {
    public AdventurerStateController mind;
    public AdventurerMovementController legs;
    public ScriptableObject attackScript;
    private AttackBehavior attack;
	// Use this for initialization
	void Start () {
        mind = GetComponent<AdventurerStateController>();
        legs = GetComponent<AdventurerMovementController>();
        attack = attackScript as AttackBehavior;
	}
	
	// Update is called once per frame
	void Update () {
        attack.update(this);
	}

    public void engage(GameObject aggro)
    {
        attack.engage(this, aggro);
    }

    public float getAttackDistance()
    {
        return attack.getAttackDistance(this);
    }
}
