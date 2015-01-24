using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float speed;

	// Use this for initialization
	void Start () {
		
		Destroy(gameObject, 5f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	
	}
}
