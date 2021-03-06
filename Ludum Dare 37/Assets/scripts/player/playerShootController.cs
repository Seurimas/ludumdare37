﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShootController : MonoBehaviour {
    public GameObject projectile;
    public int speed;
    private GameObject missile;
    private playerStatusController playerStatus;
	// Use this for initialization
	void Start () {
        playerStatus = this.GetComponent<playerStatusController>();
        projectile.GetComponent<scaleController>().scale = 1;
        projectile.GetComponent<damageController>().damageDealt = 15;
    }
	
	// Update is called once per frame
	void Update () {

        trigger_shoot();
	}

    private void trigger_shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            shoot();
        }
    }

    private void shoot()
    {
        //Create the projectile
        
        switch (playerStatus.getFaceDirection())
        {
            case 0:
                missile = Instantiate(projectile, new Vector3(0,-1.75f) + transform.position, Quaternion.AngleAxis(180, new Vector3(0, 0, 1)));
                missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
                break;
            case 1:
                missile = Instantiate(projectile, new Vector3(1.75f,0) + transform.position, Quaternion.AngleAxis(270, new Vector3(0, 0, 1)));
                missile.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
                break;
            case 2:
                missile = Instantiate(projectile, new Vector3(0, 1.75f) + transform.position, Quaternion.identity);
                missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                break;
            case 3:
                missile = Instantiate(projectile, new Vector3(-1.75f,0) + transform.position, Quaternion.AngleAxis(90, new Vector3(0, 0, 1)));
                missile.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, 0);
                break;
        }
    }
}
