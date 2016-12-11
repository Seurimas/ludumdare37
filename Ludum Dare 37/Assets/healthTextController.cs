using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthTextController : MonoBehaviour {
    public Text healthText;
    private string healthFormat;
    public playerStatusController playerStatus;
	// Use this for initialization
	void Start () {
        playerStatus = this.GetComponent<playerStatusController>();
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Player health: " + playerStatus.health.ToString();
	}
}
