using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {
    public Text goldText;
    private string goldFormat;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void initializeGUI(Text gold)
    {
        goldText = gold;
        goldFormat = gold.text;
    }
}
