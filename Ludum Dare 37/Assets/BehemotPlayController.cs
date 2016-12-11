using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemotPlayController : MonoBehaviour {
    private Animator animator;
    Rigidbody2D rb2D;
    public float speed = 10.0f;
    public GameObject fireball;
    // Use this for initialization
    int direction = 0;
    void Start () {
        animator = this.GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
      
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (y > 0)
        {
            direction = 2;
            animator.SetInteger("direction", 2);
        }
        else if (y < 0)
        {
            direction = 0;
            animator.SetInteger("direction", 0);
        }
        else if (x > 0)
        {
            direction = 1;
            animator.SetInteger("direction", 1);
        }
        else if (x < 0)
        {
            direction = 3;
            animator.SetInteger("direction", 3);
        }

        //Move
        rb2D.velocity = new Vector2(x * speed, y * speed);
        //shoot
        shoot(direction);
    }

    void shoot(int direction) {
        if (Input.GetKeyDown("space")) {

            switch (direction){
                case 0:
                    Instantiate(fireball, transform.position, Quaternion.AngleAxis(180, new Vector3(0, 0, 1)));
                    break;
                case 1:
                    Instantiate(fireball, transform.position, Quaternion.AngleAxis(270, new Vector3(0, 0, 1)));
                    break;
                case 2:
                    Instantiate(fireball, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(fireball, transform.position, Quaternion.AngleAxis(90, new Vector3(0, 0, 1)));
                    break;
                
            }
            
        }

    }
}
