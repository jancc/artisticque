using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GUISkin skin;
	public float speed;
	public Storytext[] texts;
	public int currentText;
	public string text;
	public float texttime = 0.0f;
	public float minX = -12.0f;
	public float maxX = 12.0f;
    public GameObject triggerOnStoryDone = null;
    public bool drunk = false;

	// Use this for initialization
	void Start () {
	
	}

    public void DisplayTexts(Storytext[] newtexts, float maxDistanceDuringSpeech, GameObject newTriggerOnStoryDone = null)
    {
		texts = newtexts;
		currentText = 0;
		texttime = 0.0f;
		maxX = transform.position.x + maxDistanceDuringSpeech;
        triggerOnStoryDone = newTriggerOnStoryDone;
	}

	// Update is called once per frame
	void Update () {
		
		float input = Input.GetAxis("Horizontal");

        if (drunk)
        {
            input *= Mathf.Sin(Time.time) * 0.7f + 0.3f;
        }

		if(Mathf.Abs(input) > 0.1f)
			animation.CrossFade("Walk", 0.2f);
		else
			animation.CrossFade("Stand", 0.2f);

		transform.Translate(Vector3.right * speed * input * Time.deltaTime);

		float x = transform.position.x;
		x = Mathf.Clamp(x, minX, maxX);
		transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (Input.GetMouseButtonDown(0))
            texttime = 0.0f;

		texttime -= Time.deltaTime;
		if(texttime < 0.0f) {
			text = "";
			if(currentText < texts.Length) {
				text = texts[currentText].text;
				texttime = texts[currentText].displaytime;
			}
			else {
                if (triggerOnStoryDone)
                {
                    triggerOnStoryDone.SendMessage("OnStoryTrigger");
                    triggerOnStoryDone = null;
                }
				maxX = 1000000000.0f;
			}
			currentText++;
		}

	}

	void OnGUI () {

        GUI.skin = skin;

		if(texttime > 0.0f) {
            if (drunk)
                GUI.color = Color.black;
			GUI.Label(new Rect(0, 0, Screen.width, 100.0f), text);
		}

	}

}
