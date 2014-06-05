using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	public Storytext[] texts;
	public float maxDistanceDuringSpeech;
    public GameObject triggerOnDone = null;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter (Collider hit) {
	
		if(hit.CompareTag("Player")) {
		Player player = hit.GetComponent<Player>();
        player.DisplayTexts(texts, maxDistanceDuringSpeech, triggerOnDone);
		player.minX = transform.position.x -2.0f;
		Destroy(gameObject);
		}

	}
}
