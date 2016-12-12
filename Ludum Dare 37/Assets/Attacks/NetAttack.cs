using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAttack : MonoBehaviour {
    public float amount;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        playerMoveController move = other.GetComponent<playerMoveController>();
        if (move != null)
        {
            if (other.GetComponent<Netted>() == null)
                other.gameObject.AddComponent<Netted>();
        }
    }
}
