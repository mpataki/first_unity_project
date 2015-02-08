using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	Vector3 offset;
	Player player;

	// Use this for initialization
	void Start () {
		GameObject profile_go = GameObject.Find ("Player");
		player = (Player)profile_go.GetComponent (typeof(Player));
		offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var cameraScreenCenter = (Camera.main.camera.WorldToScreenPoint( Camera.main.camera.transform.position ));
		var yOffset = Camera.main.camera.orthographicSize * 0.4f;
		var xOffset = yOffset * Camera.main.camera.aspect;
		var leftEdge  = cameraScreenCenter.x - xOffset;
		var rightEdge = cameraScreenCenter.x + xOffset;
		var playerScreenPos = camera.WorldToScreenPoint (player.transform.position);

		if (playerScreenPos.x <= leftEdge)
			this.transform.Translate( - Mathf.Abs( leftEdge - playerScreenPos.x), 0, 0 );
		else if (playerScreenPos.x >= rightEdge)
			this.transform.Translate( Mathf.Abs( rightEdge - playerScreenPos.x ), 0, 0 );

	}
}
