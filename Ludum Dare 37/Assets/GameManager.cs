using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public AdventurerManager adventurerManager;
    
	// Use this for initialization

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            DestroyObject(this);
        DontDestroyOnLoad(this);
        adventurerManager = GetComponent<AdventurerManager>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
