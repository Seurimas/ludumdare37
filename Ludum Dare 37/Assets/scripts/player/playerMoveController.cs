using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveController : MonoBehaviour {
    public float speed = 10.0f;
    Rigidbody2D rb2D;
    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb2D.velocity = new Vector2(x * speed, y * speed);
    }
}
