using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballBehavior : MonoBehaviour {

    public int speed = 0;
    public int direction = 0;
    Rigidbody2D rb2D;
    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        switch(direction)
        {
            case 1:
                rb2D.velocity = new Vector2(speed,0);
                break;
            case 3:
                rb2D.velocity = new Vector2(speed * -1, 0);
                break;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
