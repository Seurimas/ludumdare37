using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballBehavior : MonoBehaviour {

    public int speed = 0;
    public int direction = 0;
    public Rigidbody2D rb2D;
    
    // Use this for initialization
    void Start () {
        //rotate_sprite();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void rotate_sprite()
    {
        //Initialize rigidBody2D
        rb2D = GetComponent<Rigidbody2D>();
        //Get current rotation
        int my_angle = (int)transform.eulerAngles.z;

        switch (my_angle)
        {
            case 0:
                rb2D.velocity = new Vector2(0, speed);
                break;
            case 90:
                rb2D.velocity = new Vector2(speed* -1, 0);
                break;
            case 180:
                rb2D.velocity = new Vector2(0, speed* -1);
                break;
            case 270:
                rb2D.velocity = new Vector2(speed,0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Asset" || collision.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }

    }
}
