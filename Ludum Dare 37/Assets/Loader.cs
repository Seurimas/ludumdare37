using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour {
    public GameObject gameManager;
    public List<GameObject> doors;
    public List<GameObject> loots;
    public Text goldText;
    public Text timerText;
    public Text currentText;
    public Text gameOverText;
    public GameObject bahamut;
    // Use this for initialization
    void Awake() {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        GameManager.instance.adventurerManager.initialize(doors, loots);
        GameManager.instance.resourceManager.initialize(loots);
        GameManager.instance.adventurerManager.initializeGUI(timerText, currentText);
        GameManager.instance.resourceManager.initializeGUI(goldText);
        GameManager.instance.setDragon(bahamut);
        GameManager.instance.initializeGUI(gameOverText);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
