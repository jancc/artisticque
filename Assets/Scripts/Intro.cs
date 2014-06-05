using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    public GUISkin skin;
	public float bg_speed;
	public Transform bg_1;
	public Transform bg_2;
	public Transform bg_3;
	public string displaytext;
	public string[] texts;
	public int currentText = 0;
	public float timePerText;
	public float nextText;

	// Use this for initialization
	void Start () {
	
	}
	
	void fix (Transform tr)
	{
		if(tr.position.x > 79 * 2)
			tr.Translate(Vector3.left * 79 * 2);
	}

	// Update is called once per frame
	void Update () {
		
		bg_1.Translate(Vector3.right * bg_speed * Time.deltaTime);
		bg_2.Translate(Vector3.right * bg_speed * Time.deltaTime);
		bg_3.Translate(Vector3.right * bg_speed * Time.deltaTime);

		fix(bg_1);
		fix(bg_2);
		fix(bg_3);

		if(nextText < Time.time)
		{
			currentText++;
            if (currentText >= texts.Length)
                Application.LoadLevel("Ingame");
			nextText = Time.time + timePerText;
			displaytext = texts[currentText];
		}

	}

	void OnGUI () {

        GUI.skin = skin;
		GUI.Label(new Rect(0, Screen.height / 2, Screen.width, 100.0f), 			displaytext);

	}
}
