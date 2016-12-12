using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventurerShootBehavior : MonoBehaviour {
    public GameObject projectile;
    private GameObject missile;
    GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("bahamut");
        InvokeRepeating("shoot",3.0f,3.0f);
	}
	
	// Update is called once per frame
	void Update () {
        //Create a vector between adventurer and player to define projectile path
        Debug.Log(transform.position - target.transform.position);
        
    }

    private void shoot()
    {
        missile = Instantiate(projectile, new Vector3(0, -1.75f) + transform.position, Quaternion.AngleAxis(180, new Vector3(0, 0, 1)));
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * missile.GetComponent<projectileController>().speed;
    }

}

