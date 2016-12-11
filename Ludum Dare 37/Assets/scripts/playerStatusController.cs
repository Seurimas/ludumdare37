using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatusController : MonoBehaviour {
    public int face_direction;
    public int health;
	// Use this for initialization
	void Start () {
        face_direction = 0;
        health = 200;
	}
	
	// Update is called once per frame
	void Update () {
        //getFaceDirection();
        if (ImDeath())
        {
            Destroy(gameObject);
        }
    }

    public int getFaceDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y > 0) //Facing up
        {
            face_direction = 2;
        }
        else if (y < 0) //Facing down
        {
            face_direction = 0;
        }
        else if (x > 0) //Facing right
        {
            face_direction = 1;
        }
        else if (x < 0) //Facing left
        {
            face_direction = 3;
        }

        return face_direction;
    }

    private bool ImDeath() {

        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            //health -= 10;
            health -= collision.gameObject.GetComponent<SwingingWeapon>().weaponDamage;
        }
    }
}
