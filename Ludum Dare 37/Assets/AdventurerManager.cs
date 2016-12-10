using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdventurerManager : MonoBehaviour {
    public List<GameObject> adventurerPrefabs;
    public List<GameObject> doors;
    public List<GameObject> loots;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnRandomAdventurerGroup()
    {
        spawnAdventurerGroup(doors[Random.Range(0, doors.Count)], loots[Random.Range(0, loots.Count)], Random.Range(3, 6));
    }

    private void spawnAdventurerGroup(GameObject door, GameObject loot, int groupSize)
    {
        Transform spawnLocation = door.transform;
        for (int i = 0;i < groupSize;i++)
        {
            spawnAdventurer(door, loot, spawnLocation);
        }
    }

    private void spawnAdventurer(GameObject door, GameObject loot, Transform spawnLocation)
    {
        GameObject prefab = adventurerPrefabs[Random.Range(0, adventurerPrefabs.Count)];
        GameObject adventurer = Instantiate(prefab, spawnLocation.position, new Quaternion());
        adventurer.GetComponent<AdventurerController>().initialize(door, loot);
    }
}
