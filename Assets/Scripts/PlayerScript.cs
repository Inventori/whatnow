using UnityEngine;
using System;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float horiz;
	public bool grounded;
	//public bool doubleJumped;
	public float groundMultiplier;
	public float flightMultiplier;
	public float jumpForce;
	//public float doubleJumpForce;
	public float momentum;
	public Animator animator;
	public float move;

	// Use this for initialization
	void Start () {
		grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		move = Math.Abs (Input.GetAxis ("Horizontal"));
		horiz = horiz*(1-momentum) + Input.GetAxis ("Horizontal")*(momentum);

		if (grounded){
			transform.position += (new Vector3 (1, 0, 0)) * horiz * Time.deltaTime * groundMultiplier;
		} else {
			transform.position += (new Vector3 (1, 0, 0)) * horiz * Time.deltaTime * flightMultiplier;
		}

		if (Input.GetButtonDown("Jump") && grounded){
			animator.SetTrigger("JumpPressed");
			rigidbody2D.AddForce(new Vector2(horiz*flightMultiplier,jumpForce),ForceMode2D.Impulse);
			grounded = false;
		}

		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetFloat("Move", move);		
		}
		//else if(Input.GetButtonDown("Jump") && !doubleJumped){
		//	rigidbody2D.AddForce(new Vector2(horiz,doubleJumpForce),ForceMode2D.Impulse);
		//	doubleJumped = true;
		//}

		//Lol, reset :D
		if (transform.position.y < -100) {
			transform.position = new Vector3(0,0,0);
		}



	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Ground") {
			if(grounded == false) {
				horiz = 0; //Don't keep momentum when touching ground first time after jump.
				animator.SetTrigger ("Landed");
			}
			grounded = true;
			//doubleJumped = false;
		} else
			grounded = false;
	}
}
