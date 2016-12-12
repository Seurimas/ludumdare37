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
            TeamController otherTeam = collision.GetComponent<TeamController>();
            TeamController myTeam = GetComponent<TeamController>();
            if (myTeam == null || otherTeam == null || myTeam.team != otherTeam.team)
                healthController.health -= damageDealt;
        }
    }
}
