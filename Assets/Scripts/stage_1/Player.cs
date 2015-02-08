using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int speed = 10;
	Animator anim;
	Vector3 bgMinPoint;
	Vector3 bgMaxPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		GameObject bg = GameObject.Find("Background");
		bgMinPoint = bg.renderer.bounds.min;
		bgMaxPoint = bg.renderer.bounds.max;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		var delta = 1 * speed * Time.deltaTime;
		if ( Input.GetAxisRaw("Horizontal") > 0 && renderer.bounds.max.x + delta < bgMaxPoint.x )
			transform.Translate( delta, 0, 0 );
		else if ( Input.GetAxisRaw("Horizontal") < 0 && renderer.bounds.min.x - delta > bgMinPoint.x )
			transform.Translate( -delta, 0, 0 );
		else if (renderer.bounds.min.x < bgMinPoint.x)
			transform.Translate (Mathf.Abs(bgMinPoint.x - renderer.bounds.min.x), 0, 0);
		else if (renderer.bounds.max.x > bgMaxPoint.x)
			transform.Translate (-Mathf.Abs(bgMaxPoint.x - renderer.bounds.max.x), 0, 0);
	}
}
