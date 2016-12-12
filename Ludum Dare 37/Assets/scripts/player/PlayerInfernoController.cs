using UnityEngine;

public class PlayerInfernoController : MonoBehaviour {
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
        }
	}

    private void fireInferno()
    {
        float baseAngle = status.getFaceDirection() * 90 + 180;
        for (int i = 0; i < 8;i++) {
            float angle = baseAngle + Random.Range(-45, 45);
            GameObject missile = Instantiate(projectile, transform.position, Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            missile.GetComponent<Rigidbody2D>().velocity = missile.transform.rotation * new Vector2(0, missile.GetComponent<projectileController>().speed);
        }
        skillButton.startCooldown();
    }
}
