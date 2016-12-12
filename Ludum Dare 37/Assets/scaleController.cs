using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleController : MonoBehaviour {
    public int scale;
    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
        if (scale >= 1)
        {
            transform.localScale = new Vector3(scale,scale,0);
        }
    }
}
