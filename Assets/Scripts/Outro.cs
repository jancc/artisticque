using UnityEngine;
using System.Collections;

public class Outro : MonoBehaviour {

    public GUISkin skin;
	public string displaytext;
	public string[] texts;
	public int currentText = 0;
	public float timePerText;
	public float nextText;
    public Texture2D black;
    public bool display;
    public bool anykey = false;

	// Use this for initialization
	void Start () {
	
	}

    void OnStoryTrigger()
    {
        display = true;
    }

	// Update is called once per frame
	void Update () {

        if (!display)
            return;

        if(anykey && Input.GetMouseButtonDown(0))
            Application.LoadLevel("Menu");

		if(!anykey && nextText < Time.time)
		{
			currentText++;
			if (currentText >= texts.Length) {
				anykey = true;
				return;
			}
			nextText = Time.time + timePerText;
			displaytext = texts[currentText];
		}

	}

	void OnGUI () {

        if (!display)
            return;

        GUI.skin = skin;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), black);
		GUI.Label(new Rect(0, Screen.height / 2, Screen.width, 100.0f), 			displaytext);

        if(anykey)
            GUI.Label(new Rect(0, Screen.height - 100.0f, Screen.width, 100.0f), "Press Mouse Left to return to menu");

	}
}
