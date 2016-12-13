using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerManager : MonoBehaviour {
    public List<GameObject> adventurerPrefabs;
    private List<GameObject> doors;
    private List<GameObject> loots;
    public int waveCount;
    public Text timerText, currentText;
    private string timerFormat, currentFormat;
    public void initialize(List<GameObject> doors, List<GameObject> loots)
    {
        waveCount = 0;
        this.doors = doors;
        this.loots = loots;
    }
    public void initializeGUI(Text timerText, Text currentText)
    {
        this.timerText = timerText;
        this.currentText = currentText;
        timerFormat = timerText.text;
        currentFormat = currentText.text;
    }
    // Use this for initialization
    void Start () {
		
	}
    public float waveGap = 5f;
    private float waveProgress = 0;
	// Update is called once per frame
	void Update () {
        if (timerText == null || currentText == null)
            return; // We're not active right now.
        int adventurersLeft = getAdventurerCount();
        if (adventurersLeft > 0)
        {
            waveProgress = 0;
            timerText.text = string.Format(timerFormat, waveCount, (int)(waveGap - waveProgress));
            currentText.text = string.Format(currentFormat, adventurersLeft);
        } else
        {
            waveProgress += Time.deltaTime;
            if (waveProgress > waveGap)
            {
                waveCount++;
                spawnRandomAdventurerGroup();
            }
            timerText.text = string.Format(timerFormat, waveCount, (int)(waveGap - waveProgress));
            currentText.text = "";
        }
	}

    public int getAdventurerCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void spawnRandomAdventurerGroup()
    {
        int min = 3 + Mathf.Min(waveCount / 5, 3);
        int max = 4 + Mathf.Min(waveCount / 3, 6);
        spawnAdventurerGroup(doors[Random.Range(0, doors.Count)], loots[Random.Range(0, loots.Count)], Random.Range(min, max));
    }

    private void spawnAdventurerGroup(GameObject door, GameObject loot, int groupSize)
    {
        Vector3 spawnLocation = door.transform.position;
        for (int i = 0;i < groupSize;i++)
        {
            spawnAdventurer(door, loot, spawnLocation);
            spawnLocation = spawnLocation + new Vector3(0, -1, 0);
        }
    }

    private void spawnAdventurer(GameObject door, GameObject loot, Vector3 spawnLocation)
    {
        GameObject prefab = adventurerPrefabs[Random.Range(0, adventurerPrefabs.Count)];
        GameObject adventurer = Instantiate(prefab, spawnLocation, new Quaternion());
        adventurer.GetComponent<AdventurerStateController>().initialize(door, loot);
        if (waveCount > 5 && Random.value > 0.5f)
        {
            adventurer.GetComponent<AdventurerStateController>().cashoutValue += 1f;
        }
        if (waveCount > 5 && adventurer.GetComponent<WeaponSwing>() != null)
        {
            adventurer.GetComponent<WeaponSwing>().damageDealt += Mathf.Min(Random.value * waveCount, 20);
        }
        if (waveCount > 5 && adventurer.GetComponent<HitAndRun>() != null)
        {
            HitAndRun hitAndRun = adventurer.GetComponent<HitAndRun>();
            hitAndRun.cooldown = Mathf.Max(hitAndRun.cooldown - Random.value * waveCount / 3, 1);
        }
        if (waveCount > 5 && adventurer.GetComponent<adventurerShootBehavior>() != null)
        {
            adventurerShootBehavior shoot = adventurer.GetComponent<adventurerShootBehavior>();
            shoot.interval = shoot.interval / Mathf.Min(Mathf.Max(1, Random.value * waveCount / 3), 4);
        }
        if (waveCount > 10 && adventurer.GetComponent<healthController>() != null)
        {
            adventurer.GetComponent<healthController>().health += waveCount * Random.value;
        }
    }

}
