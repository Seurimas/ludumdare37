using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AdventurerAttackController : MonoBehaviour {
    private AdventurerStateController mind;
    private AdventurerMovementController legs;
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
        attack.update(gameObject);
	}

    public void engage(GameObject aggro)
    {
        attack.engage(gameObject, aggro);
    }

    public int getAttackDistance()
    {
        return attack.getAttackDistance(gameObject);
    }
}
