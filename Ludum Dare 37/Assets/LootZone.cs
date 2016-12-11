using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootZone : MonoBehaviour {
    public float gold = 40;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float loot(float amount)
    {
        if (gold > amount)
        {
            gold -= amount;
            return amount;
        } else
        {
            float temp = gold;
            gold = 0;
            return temp;
        }
    }

    public static LootZone getRandomWithLoot()
    {
        List<LootZone> lootZones = new List<LootZone>();
        foreach (LootZone lootZone in GameObject.FindObjectsOfType<LootZone>())
        {
            if (lootZone.gold > 0)
                lootZones.Add(lootZone);
        }
        if (lootZones.Count > 0)
            return lootZones[Random.Range(0, lootZones.Count)];
        else
            return null;
    }
}
