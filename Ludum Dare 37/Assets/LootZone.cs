using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootZone : MonoBehaviour {
    public float gold = 40;
    public AudioClip lootNoise;
    private float lastGold;
	// Use this for initialization
	void Start () {
        lastGold = (int) gold;
        GetComponent<AudioSource>().clip = lootNoise;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void accrue(float amount)
    {
        gold += amount;
        lastGold = gold;
    }

    public float loot(float amount)
    {
        if (gold > amount)
        {
            gold -= amount;
            if (lastGold - gold >= 1)
            {
                playNoise();
                lastGold -= 1;
            }
            return amount;
        } else
        {
            float temp = gold;
            gold = 0;
            playNoise();
            return temp;
        }
    }

    private void playNoise()
    {
        GetComponent<AudioSource>().Play();
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
