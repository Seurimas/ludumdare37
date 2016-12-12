using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {
    public enum TEAM
    {
        ADVENTURER,
        PLAYER
    };
    public TEAM team;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static bool areDifferentTeam(GameObject first, GameObject second)
    {
        TeamController otherTeam = first.GetComponent<TeamController>();
        TeamController myTeam = second.GetComponent<TeamController>();
        return (otherTeam == null || myTeam == null || myTeam.team != otherTeam.team);
    }
}
