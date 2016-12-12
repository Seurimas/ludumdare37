using UnityEngine;

public class PlayerScorchedController : MonoBehaviour {
    public SkillController skillButton;
    public GameObject areaEffect;
    private bool active = false;
    private float progress = 0;
    public float duration = 3f;
    public float interval = 0.25f;
    private float sinceLast = 0;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!skillButton.onCooldown() && Input.GetKeyDown(skillButton.key))
        {
            startScorch();
            skillButton.startCooldown();
        } else if (active && progress < duration)
        {
            sinceLast += Time.deltaTime;
            progress += Time.deltaTime;
            if (sinceLast > interval)
            {
                sinceLast -= interval;
                Instantiate(areaEffect, transform.position, Quaternion.identity);
            }
        } else if (active && progress >= duration)
        {
            endScorch();
        }
	}

    private void startScorch()
    {
        active = true;
        progress = 0;
    }
    private void endScorch()
    {
        active = false;
        foreach (ScorchedDamage flames in GameObject.FindObjectsOfType<ScorchedDamage>())
        {
            Destroy(flames.gameObject);
        }
    }
}
