using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {
    private List<GameObject> loots;
    public Text goldText;
    private string goldFormat;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float goldCount = 0;
		foreach (GameObject loot in loots)
        {
            goldCount += loot.GetComponent<LootZone>().gold;
        }
        goldText.text = string.Format(goldFormat, (int) goldCount);
	}
    public void initialize(List<GameObject> loots)
    {
        this.loots = loots;
    }
    public void initializeGUI(Text gold)
    {
        goldText = gold;
        goldFormat = gold.text;
    }
}
