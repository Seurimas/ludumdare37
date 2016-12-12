using UnityEngine;

public class PlayerBurstController : MonoBehaviour {
    public SkillController skillButton;
    private playerMoveController move;
    private bool boosted = false;
    private float timeSinceBoost = 0;
    public float duration = 4;
    // Use this for initialization
    void Start () {
        move = GetComponent<playerMoveController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!skillButton.onCooldown() && Input.GetKeyDown(skillButton.key))
        {
            speedBoost();
            skillButton.startCooldown();
        } else if (timeSinceBoost > duration && boosted)
        {
            
        }
	}

    private void speedBoost()
    {
        timeSinceBoost = 0;
        boosted = true;
        move.speed += 5;
    }
    private void endBoost()
    {
        boosted = false;
        move.speed -= 5;
    }
}
