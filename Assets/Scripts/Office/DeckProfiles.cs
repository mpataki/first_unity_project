using UnityEngine;
using System.Collections;

public class DeckProfiles : MonoBehaviour {

	public Vector3 velocity;
	public float acceleration_y;
	float startingPos;
	Vector3 acceleration = new Vector3(0, 1, 0);
	bool pressed = false;

	void Start(){
		startingPos = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed) return;

		if (this.transform.position.y > startingPos) 
			acceleration.y = -acceleration_y;
		else 
			acceleration.y = acceleration_y;

		velocity += (acceleration * Time.deltaTime);
		this.transform.Translate( velocity * Time.deltaTime );
	}

	void OnMouseDown(){
		GameObject profile_go = GameObject.Find ("Profile");
		Profile profile = (Profile)profile_go.GetComponent (typeof(Profile));
		if (!pressed) {
			profile.StartShowProfile ();
			pressed = true;
		}
	}
}
