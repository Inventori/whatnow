using UnityEngine;
using System.Collections;

public class LoadingLevelNext : MonoBehaviour {
	int i;
	public BoxCollider2D box;
	
	// Use this for initialization
	void Start () {
		i = 0;
	print (Application.loadedLevel);
		box = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		i = Application.loadedLevel + 1;
		Application.LoadLevel (i);
		//box.enabled = false;
	}
}
