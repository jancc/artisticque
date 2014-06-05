using UnityEngine;
using System.Collections;

public class NewDay : MonoBehaviour {

    public Player player;
    public string text;
    public float time;
    public Texture2D black;
    public GUISkin skin;
    bool display;
    float endTime;
    float alpha = 1.0f;
    float oldSpeed;

	// Use this for initialization
	void Start () {

        oldSpeed = player.speed;
        player.speed = 0.0f;
        display = true;
        endTime = Time.time + time;

	}
	
	void OnGUI () {

        if (!display)
            return;

        if (Time.time > endTime)
        {
            alpha -= Time.deltaTime / 2.0f;
        }

        if (alpha < 0)
        {
            player.speed = oldSpeed;
            display = false;
        }

        GUI.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        GUI.skin = skin;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), black);
        GUI.Label(new Rect(0, 0, Screen.width, 100.0f), text);
     

	}
}
