using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {
    private Light brazierLight;
    private float progress = 0;
    public float maxIntensity = 0.75f;
    public float minIntensity = 0.5f;
    public float flickerInterval = 1f;
	// Use this for initialization
	void Start () {
        brazierLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update () {
        progress += Time.deltaTime;
        float flickerProgress = progress % flickerInterval;
        float flickerAngle = flickerProgress * Mathf.PI * 2 / flickerInterval;
        float flickerRange = (maxIntensity - minIntensity);
        float flickerIntensity = Mathf.Cos(flickerAngle / 2) + Mathf.Sin(flickerAngle * 3);
        flickerIntensity /= 2;
        flickerIntensity += 1;
        flickerIntensity += Random.value / 4f;
        brazierLight.intensity = flickerIntensity * flickerRange + minIntensity;
    }
}
