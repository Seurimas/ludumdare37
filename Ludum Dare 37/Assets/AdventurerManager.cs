using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerManager : MonoBehaviour {
    public List<GameObject> adventurerPrefabs;
    private List<GameObject> doors;
    private List<GameObject> loots;
    private Text timerText, currentText;
    private string timerFormat, currentFormat;
    public void initialize(List<GameObject> doors, List<GameObject> loots)
    {
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
        int adventurersLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (adventurersLeft > 0)
        {
            waveProgress = 0;
            timerText.text = "";
            currentText.text = string.Format(currentFormat, adventurersLeft);
        } else
        {
            waveProgress += Time.deltaTime;
            if (waveProgress > waveGap)
            {
                spawnRandomAdventurerGroup();
            }
            timerText.text = string.Format(timerFormat, (int)(waveGap - waveProgress));
            currentText.text = "";
        }
	}

    public void spawnRandomAdventurerGroup()
    {
        spawnAdventurerGroup(doors[Random.Range(0, doors.Count)], loots[Random.Range(0, loots.Count)], Random.Range(3, 6));
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
        adventurer.GetComponent<SpriteRenderer>().sprite = adventurer.GetComponent<AdventurerSpriteSet>().getRandomSprite();
    }

}
