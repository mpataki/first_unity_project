using UnityEngine;
using System.Collections;

public class SuspectPic : MonoBehaviour {

	public Vector3 velocity;
	public float acceleration_y;
	public int levelToLoad;
	float startingPos;
	Vector3 acceleration = new Vector3(0, 1, 0);
	bool pressed = false;
	bool started = false;

	public void initializeSway(){
		startingPos = this.transform.position.y;
		started = true;
	}

	// Update is called once per frame
	void Update () {
		if (!started) return;

		if (this.transform.position.y > startingPos) 
			acceleration.y = -acceleration_y;
		else 
			acceleration.y = acceleration_y;
		
		velocity += (acceleration * Time.deltaTime);
		this.transform.Translate( velocity * Time.deltaTime );
	}
	
	void OnMouseDown(){
		Application.LoadLevel( levelToLoad );
	}
}
