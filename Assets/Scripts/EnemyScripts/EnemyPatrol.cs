using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {
	
	public float speed;
	
	private float step;
	
	
	private bool moveRight;
	
	private Vector2 fwd;
	private Vector2 down;
	
	
	public LayerMask mask = 8;

	// Use this for initialization
	void Start () {
		
		
		
	
		
		moveRight = true;
		
		fwd = new Vector2 (70, -45);
		down = new Vector2 (0, -90);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, fwd, 2, mask.value);
		
		if(hit.collider != null)
		{
			
			moveRight = true;
		}
		else 
		{
			
			moveRight = false;
		}
		
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -Vector2.right, 1, mask.value);
		
		if(hitLeft.collider != null)
		{
			if (moveRight)
			{
				moveRight = false;
			}
			else 
			{
				moveRight = true;
			}
		}
		
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 1, mask.value);
		
		if (hitRight.collider != null)
		{
			if (moveRight)
			{
					moveRight = false;
			}
			else 
			{
				moveRight = true;
			}
		}
		
		if (moveRight)
		{
			
			transform.Rotate(0, 0, 0);
		}
		else 
		{
			
			transform.Rotate(0, 180, 0);
		}
		
		
		if (transform.eulerAngles.y < 180)
		{
			fwd = new Vector2(70, -45);

		}
		else 
		{
			fwd = new Vector2 (-70, -45);	

		}
		
	
		transform.Translate (Vector2.right * speed * Time.deltaTime);

	
		
		
		
		
		
	
		
	}
	
	
	
		
		
		
		
}
