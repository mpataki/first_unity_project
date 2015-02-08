using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	Vector3 offset;
	Player player;
	Vector3 bgMinPoint;
	Vector3 bgMaxPoint;

	// Use this for initialization
	void Start () {
		GameObject profile_go = GameObject.Find("Player");
		player = (Player)profile_go.GetComponent(typeof(Player));
		offset = transform.position - player.transform.position;

		GameObject bg = GameObject.Find("Background");
		bgMinPoint = bg.renderer.bounds.min;
		bgMaxPoint = bg.renderer.bounds.max;
	}
	
	// Update is called once per frame
	void Update () {
		var cameraScreenCenter = (camera.WorldToScreenPoint( camera.transform.position ));
		var yOffset = camera.orthographicSize * 0.3f;
		var xOffset = yOffset * camera.aspect;
		var leftEdge  = cameraScreenCenter.x - xOffset;
		var rightEdge = cameraScreenCenter.x + xOffset;
		var playerScreenPos = camera.WorldToScreenPoint (player.transform.position);

		Vector3 halfScreenWidth = new Vector3(camera.orthographicSize * camera.aspect, 0, 0);
		var leftCameraEdge  = camera.transform.position - halfScreenWidth;
		var rightCameraEdge = camera.transform.position + halfScreenWidth;

		float leftDelta  = Mathf.Abs( leftEdge - playerScreenPos.x );
		float rightDelta = Mathf.Abs( rightEdge - playerScreenPos.x );

		if (playerScreenPos.x <= leftEdge && (leftCameraEdge.x - leftDelta) > bgMinPoint.x)
			transform.Translate( - leftDelta, 0, 0 );
		else if (playerScreenPos.x >= rightEdge && (rightCameraEdge.x + rightDelta) < bgMaxPoint.x )
			transform.Translate( rightDelta, 0, 0 );
	}
}
