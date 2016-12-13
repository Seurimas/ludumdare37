using System;
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
	void Update ()
    {
        if (goldText == null)
            return; // We're not active right now.
        
        goldText.text = string.Format(goldFormat, getGold());
	}

    public int getGold()
    {
        float goldCount = 0;
        foreach (GameObject loot in loots)
        {
            if (loot != null)
                goldCount += loot.GetComponent<LootZone>().gold;
        }
        return (int)goldCount;
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

    internal void accrue(float v)
    {
        foreach (GameObject loot in loots)
        {
            loot.GetComponent<LootZone>().gold += v / loots.Count;
        }
    }
}
