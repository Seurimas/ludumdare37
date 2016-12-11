using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShootController : MonoBehaviour {
    public GameObject projectile;
    public playerStatusController playerStatus;
    // Use this for initialization
    void Start () {
		playerStatus = this.GetComponent<playerStatusController>();
	}
	
	// Update is called once per frame
	void Update () {
        shoot(playerStatus.getFaceDirection());
	}

    void shoot(int direction)
    {
        if (Input.GetKeyDown("space"))
        {
            switch (direction)
            {
                case 0:
                    Instantiate(projectile, transform.position, Quaternion.AngleAxis(180, new Vector3(0, 0, 1)));
                    break;
                case 1:
                    Instantiate(projectile, transform.position, Quaternion.AngleAxis(270, new Vector3(0, 0, 1)));
                    break;
                case 2:
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(projectile, transform.position, Quaternion.AngleAxis(90, new Vector3(0, 0, 1)));
                    break;

            }

        }

    }
}
