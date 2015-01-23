using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float move;
	private float horiz;

	// Use this for initialization
	void Start () {

		move = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		horiz = Input.GetAxis ("Horizontal");

		if (Input.GetAxis("Horizontal") != 0)
		    {
			transform.position += Vector3.right * move * horiz;
		}
	/*	if (Input.GetButtonDown ("Jump")) {
			rigidbody2D.velocity = Vector3(0,10,0);
				}*/
	}
}
