using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
	public ParticleSystem pSystem;
	private Vector2 mousePos;

	// Use this for initialization
	void Start () {
		pSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pSystem.transform.position = mousePos;
	}
}
