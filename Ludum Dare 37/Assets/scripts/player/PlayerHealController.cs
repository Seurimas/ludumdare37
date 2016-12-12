using UnityEngine;

public class PlayerHealController : MonoBehaviour {
    public SkillController skillButton;
    public float healAmount = 50;
    private healthController health;
    // Use this for initialization
    void Start () {
        health = GetComponent<healthController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!skillButton.onCooldown() && Input.GetKeyDown(skillButton.key))
        {
            health.health += healAmount;
            skillButton.startCooldown();
        }
	}
}
