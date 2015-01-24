using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {
	
	public float sawRotationSpeed = 8f;
	
	public GameObject enemy;
	
	private Vector3 dir;
	
	// Use this for initialization
	void Start () {
		
		if (enemy.collider != null)
		{
			Physics.IgnoreCollision(gameObject.collider, enemy.collider);
		}
		dir = new Vector3(0, 0, 1);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, sawRotationSpeed * Time.deltaTime);
		
		
	
	}
}
