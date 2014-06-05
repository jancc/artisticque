using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GUISkin skin;
	public string text;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
            Application.LoadLevel("Intro");


	}

	void OnGUI () {

        GUI.skin = skin;
        GUI.Label(new Rect(0, Screen.height - 100.0f, Screen.width, 100.0f), "Press Mouse Left to start");

	}
}
