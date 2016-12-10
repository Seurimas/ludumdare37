using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
    public GameObject gameManager;
    public List<GameObject> doors;
    public List<GameObject> loots;
    // Use this for initialization
    void Awake() {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        GameManager.instance.adventurerManager.doors = doors;
        GameManager.instance.adventurerManager.loots = loots;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
