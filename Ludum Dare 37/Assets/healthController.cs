using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour {
    public int health;
    public Text healthText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Player health: " + health.ToString();
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
            health -= collision.gameObject.GetComponent<SwingingWeapon>().weaponDamage;
            if (health < 0)
            {
                health = 0;
            }
        }
    }
}
