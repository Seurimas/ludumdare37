using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleController : MonoBehaviour {
    public float scale;
    public float maxScale;
    // Use this for initialization
    void Start()
    {
        ScaleControl();
    }
	// Update is called once per frame
	void Update () {
        ScaleControl();
    }

    private void ScaleControl()
    {
        if (scale > maxScale)
        {
            scale = maxScale;
        }

        if (scale >= 1)
        {
            transform.localScale = new Vector3(scale, scale, 0);
        }
    }
}
