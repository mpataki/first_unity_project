using UnityEngine;
using System.Collections;

public class Profile : MonoBehaviour {

	public int topPos;
	Vector2 velocity;

	// Use this for initialization
	void Start () {
		velocity.x = 0;
		velocity.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ( velocity.y != 0 ) {
			this.transform.Translate(0, velocity.y * Time.deltaTime, 0);
			if (this.transform.position.y >= topPos) velocity.y = 0;
		}
	}

	public void StartShowProfile() {
		velocity.y = 1000;
	}
}
