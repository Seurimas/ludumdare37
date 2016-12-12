using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventurerShootBehavior : MonoBehaviour {
    GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("bahamut");
	}
	
	// Update is called once per frame
	void Update () {
        //Create a vector between adventurer and player to define projectile path
        Debug.Log(target.transform.position);
	}
}
