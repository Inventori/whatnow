using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float move;
	private float horiz;
	public bool grounded;

	// Use this for initialization
	void Start () {

		move = 10f;
		grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		horiz = Input.GetAxis ("Horizontal");

		if (Input.GetAxis("Horizontal") != 0 && grounded)
		    {
			rigidbody2D.AddForce(new Vector2(10,0) * horiz * move);

			//transform.position += Vector3.right * move * horiz * Time.deltaTime;
		}
		if (Input.GetButtonDown("Jump") && grounded)
		{
			rigidbody2D.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
			grounded = false;
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Ground") {
						grounded = true;
				} else
						grounded = false;
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Ground") {		
						grounded = false;
				}
		}
}
