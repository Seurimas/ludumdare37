﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour {
    public float health;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AmIDead();
	}

    public bool AmIDead()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }

    }
}
