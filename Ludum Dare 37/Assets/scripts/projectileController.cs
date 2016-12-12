using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
    public Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asset" || collision.gameObject.tag == "Map" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
