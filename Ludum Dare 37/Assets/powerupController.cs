using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupController : MonoBehaviour {
    public int type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyObject(gameObject);
            PowerUpManager(type, collision.gameObject);
            //Print the players proyectile scale
            
        }
    }

    private void PowerUpManager(int type, GameObject gameObject)
    {
        switch (type)
        {
            case 0:
                gameObject.GetComponent<playerShootController>().projectile.GetComponent<scaleController>().scale += 1;
                gameObject.GetComponent<playerShootController>().projectile.GetComponent<damageController>().damageDealt *= 2;
                break;
            case 1:
                
                break;
        }
    }
}
