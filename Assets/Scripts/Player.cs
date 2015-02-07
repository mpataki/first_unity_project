using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int speed = 10;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		if (Input.GetAxisRaw("Horizontal") > 0) {
			this.transform.Translate (1 * speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetAxisRaw("Horizontal") < 0) {
			this.transform.Translate (-1 * speed * Time.deltaTime, 0, 0);
		}
	}

}
