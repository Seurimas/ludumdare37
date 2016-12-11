using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public AdventurerManager adventurerManager;
    public ResourceManager resourceManager;
    
	// Use this for initialization

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            DestroyObject(this);
        DontDestroyOnLoad(this);
        adventurerManager = GetComponent<AdventurerManager>();
        resourceManager = GetComponent<ResourceManager>();
    }
	void Start () {
    }
    bool spawned = false;
	// Update is called once per frame
	void Update () {
	}
}
