using UnityEngine;
using System.Collections;

public class Suspect : MonoBehaviour {

	GameObject thoughtBubble;

	// Use this for initialization
	void Start () {
		thoughtBubble = transform.FindChild ("thought bubble").gameObject;
		thoughtBubble.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("got here");
		if (coll.gameObject.tag == "Player")
			thoughtBubble.renderer.enabled = true;
	}
}
