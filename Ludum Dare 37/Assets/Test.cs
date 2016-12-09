using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    public float speed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = (Input.GetAxis("Horizontal")*100);
        float y = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, y) * Time.deltaTime * speed;
	}
}
