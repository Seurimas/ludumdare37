using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemotPlayController : MonoBehaviour {
    private Animator animator;
    public Rigidbody2D rb2D;
    public float speed = 10.0f;
    // Use this for initialization
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
            animator.SetInteger("direction", 2);
        }
        else if (y < 0)
        {
            animator.SetInteger("direction", 0);
        }
        else if (x > 0)
        {
            animator.SetInteger("direction", 1);
        }
        else if (x < 0)
        {
            animator.SetInteger("direction", 3);
        }

        //transform.position += new Vector3(x, y) * Time.deltaTime * speed;
        rb2D.velocity = new Vector2(x * speed, y * speed);
    }
}
