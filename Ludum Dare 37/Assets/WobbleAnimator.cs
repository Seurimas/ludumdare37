using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleAnimator : MonoBehaviour {
    private float progress = 0;
    public float speed = 2;
    public float intensity = 0.25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float lastPoint = Mathf.Sin(progress) * intensity;
        progress += Time.deltaTime * speed;
        float currentPoint = Mathf.Sin(progress) * intensity;
        transform.position += new Vector3(0, currentPoint - lastPoint, 0);
	}
}
