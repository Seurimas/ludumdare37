using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropController : MonoBehaviour {
    Vector3 position;
    public GameObject loot;
    public float chance = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnDisable()
    {
        if (GetComponent<healthController>().AmIDead() && Random.value < chance)
        {
            position = transform.position;
            Instantiate(loot, position, Quaternion.identity);
        }
    }
}
