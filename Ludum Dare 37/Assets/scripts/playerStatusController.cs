using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatusController : MonoBehaviour {
    public int face_direction = 0;
    public int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getFaceDirection();
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
}
