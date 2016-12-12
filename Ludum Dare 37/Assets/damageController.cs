using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageController : MonoBehaviour {
    public int damageDealt;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthController healthController = collision.gameObject.GetComponent<healthController>();
        if (healthController != null)
        {
            if (TeamController.areDifferentTeam(gameObject, collision.gameObject))
                healthController.health -= damageDealt;
        }
    }
}
