using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerSpriteSet : MonoBehaviour {
    public List<Sprite> sprites;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Sprite getRandomSprite()
    {
        return sprites[Random.Range(0, sprites.Count)];
    }
}
