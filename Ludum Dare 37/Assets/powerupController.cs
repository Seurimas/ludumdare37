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
                gameObject.GetComponent<playerShootController>().projectile.GetComponent<scaleController>().scale += 0.1f;
                gameObject.GetComponent<playerShootController>().projectile.GetComponent<damageController>().damageDealt *= 1.1f;
                break;
            case 1:
                GameManager.instance.resourceManager.accrue(Random.Range(1, 2.5f));
                break;
            case 2:
                gameObject.GetComponent<healthController>().health += Random.Range(10, 25);
                break;
        }
    }
}
