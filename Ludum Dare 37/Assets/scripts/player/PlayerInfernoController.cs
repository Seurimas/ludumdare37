using UnityEngine;

public class PlayerInfernoController : MonoBehaviour {
    public int speed;
    public SkillController skillButton;
    public GameObject projectile;
    private playerStatusController status;
    // Use this for initialization
    void Start () {
        status = GetComponent<playerStatusController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!skillButton.onCooldown() && Input.GetKeyDown(skillButton.key))
        {
            fireInferno();
            skillButton.startCooldown();
        }
	}

    private void fireInferno()
    {
        int size = 8;
        float baseAngle = status.getFaceDirection() * 90 + 180;
        for (int i = 0; i < size; i++) {
            float angle = baseAngle + (90f / size) * i - 45f;
            GameObject missile = Instantiate(projectile, transform.position, Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            missile.GetComponent<Rigidbody2D>().velocity = missile.transform.rotation * new Vector2(0, speed);
        }
    }
}
