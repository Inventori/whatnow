using UnityEngine;
using System.Collections;

public class MinigunReversedScript : MonoBehaviour {
	
	public GameObject ammoPrefab;
	public GameObject hitPrefab;
	public GameObject player;
	public PlayerScript pS;
	public float ammoInterwall;
	
	private float timer;
	private Vector3 spawnPoint;
	
	private bool moveUp;
	
	public LayerMask mask = 8;
	
	public float speed = 1;
	
	
	
	

	// Use this for initialization
	void Start () {
		
		timer = 0;
		
		player = GameObject.FindGameObjectWithTag("Player");
		pS = player.GetComponent<PlayerScript>();
		
		spawnPoint = new Vector3(transform.position.x - 0.35f, transform.position.y, transform.position.z);
		
		moveUp = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		spawnPoint = new Vector3(transform.position.x - 0.35f, transform.position.y + 0.1f, transform.position.z);
		
		if (timer > ammoInterwall)
		{
			
			Instantiate(ammoPrefab, spawnPoint, Quaternion.Euler(0, -90, 180));
			RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 20, mask.value);
			
			if (hit.collider != null)
			{
				
				Instantiate(hitPrefab, hit.point, Quaternion.identity);
				
				if (hit.collider.tag == "Player")
				{
					pS.hitPoint--;
					//Whatever you want to happen to poor player
				}
			}
			
			timer = 0.0f;
		}
		
		
		RaycastHit2D upwards = Physics2D.Raycast(transform.position, Vector2.up, 1, mask.value);
		
		if (upwards.collider != null)
		{
			moveUp = false;
		}
		
		RaycastHit2D downwards = Physics2D.Raycast(transform.position, -Vector2.up, 1, mask.value);
		
		if (downwards.collider != null)
		{
			moveUp = true;
		}
		
		if(moveUp)
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else 
		{
			transform.Translate(-Vector2.up * speed * Time.deltaTime);
		}
	
	}
}