using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour {
    public GameObject bahamut;
    public float cooldown = 5f;
    public KeyCode key;
    private float timeSinceLast;
    private Rect rect;
    private Texture2D texture;
	// Use this for initialization
	void Start () {
        timeSinceLast = 0;
        RectTransform buttonTransform = GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        buttonTransform.GetWorldCorners(corners);
        rect = new Rect(new Vector2(corners[0].x, Screen.height - corners[0].y), new Vector2(corners[2].x - corners[0].x, corners[2].y - corners[0].y));
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.red);
        texture.Apply();
        texture.wrapMode = TextureWrapMode.Repeat;
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLast += Time.deltaTime;
    }

    public void OnGUI()
    {
        if (timeSinceLast < cooldown)
        {
            float percent = timeSinceLast / cooldown;
            float fillHeight = rect.height * (1 - percent);
            UnityEngine.GUI.DrawTexture(new Rect(rect.x, rect.y - fillHeight, rect.width, fillHeight), texture);
        } else
        {
            UnityEngine.GUI.Label(new Rect(rect.x, rect.y - rect.height - 8, 16, 24), key.ToString());
        }
    }
}
