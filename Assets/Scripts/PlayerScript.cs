using UnityEngine;
using System;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private static Vector3 horizontalV = new Vector3 (1, 0, 0);

	private float horiz, vertic;
	public bool grounded;
	//public bool doubleJumped;
	//public float doubleJumpForce;
	public float groundMultiplier;
	public float flightMultiplier;
	public float jumpForce;
	public float momentum;
	public Animator animator;
	public float move;
	public int hitPoint;

	// Use this for initialization
	void Start () {
		grounded = true;
		hitPoint = 1;
		//facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		move = Math.Abs (Input.GetAxis ("Horizontal"));
		horiz = horiz*(1-momentum) + Input.GetAxis ("Horizontal")*(momentum);
		vertic = vertic*(1-momentum) + Input.GetAxis ("Vertical")*(momentum);

		if (grounded){
			transform.position += horizontalV * horiz * Time.deltaTime * groundMultiplier;
		} else {
			transform.position += horizontalV * horiz * Time.deltaTime * flightMultiplier;
		}

		if (Input.GetButtonDown("Jump") && grounded){
			transform.SetParent(null);
			animator.SetTrigger("JumpPressed");
			rigidbody2D.AddForce(new Vector2(horiz*flightMultiplier,jumpForce),ForceMode2D.Impulse);
			grounded = false;
		}

		//:3
		//if (Input.GetAxis ("Horizontal") < 0 && facingRight || Input.GetAxis ("Horizontal") > 0 && !facingRight)
		//{
		//	facingRight = !facingRight;
		//	transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		//}

		Vector3 scale = transform.localScale;
		float xScale = Math.Abs(scale.x);
		if (Input.GetAxis ("Horizontal") < 0) {
			scale.x = -xScale;
		} else if (Input.GetAxis ("Horizontal") > 0) {
			scale.x = xScale;
		}
		transform.localScale = scale;

		animator.SetFloat("Move", move);
	
		//else if(Input.GetButtonDown("Jump") && !doubleJumped){
		//	rigidbody2D.AddForce(new Vector2(horiz,doubleJumpForce),ForceMode2D.Impulse);
		//	doubleJumped = true;
		//}

		//Lol, reset :D
		if (transform.position.y < -100) {
			transform.position = new Vector3(0,0,0);
		}
		
		if(hitPoint <= 0){
			//PLAYER BITES THE BUCKET
			gameObject.SetActive(false);
		}
		//RaycastHit2D hit = Physics2D.Raycast(transform.position, down, 2, 0);

	}

	void OnTriggerStay2D(Collider2D col){

		switch(col.gameObject.tag){
		case "Ground":
			break;
		case "MovingGround":
			MovingPlatform p = col.gameObject.GetComponentInParent<MovingPlatform>();
			if(p != null) transform.SetParent(col.gameObject.transform);
			break;
		case "Ladder":
			break;
		}
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!grounded) {
			horiz = 0; //Don't keep momentum when touching ground first time after jump.
			animator.SetTrigger ("Landed");
			grounded = true;
		}
		
	}
}
