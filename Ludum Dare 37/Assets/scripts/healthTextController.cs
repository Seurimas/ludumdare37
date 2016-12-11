using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthTextController : MonoBehaviour {
    public Text healthText;
    private healthController healthController;
	// Use this for initialization
	void Start () {
        healthController = this.GetComponent<healthController>();
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Player health: " + healthController.health.ToString();
	}
}
