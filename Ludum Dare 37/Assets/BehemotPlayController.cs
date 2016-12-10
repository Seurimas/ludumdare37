using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemotPlayController : MonoBehaviour {
    private Animator animator;
    public float speed = 10.0f;
    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
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

        transform.position += new Vector3(x, y) * Time.deltaTime * speed;
    }
}
