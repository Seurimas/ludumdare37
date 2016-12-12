using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
    public Rigidbody2D rb2d;
    public int scale;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (scale != 1)
        {
            transform.localScale = new Vector3(scale,scale,0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asset" || collision.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
