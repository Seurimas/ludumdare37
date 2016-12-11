using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour {
    public int health;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AmIDead();
	}

    private bool AmIDead()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (gameObject.tag != "Enemy")
            {
                health -= collision.gameObject.GetComponent<SwingingWeapon>().weaponDamage;
            }
        }

        if (health < 0)
        {
            health = 0;
        }
    }
}
