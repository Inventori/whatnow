using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject camera;
	public SpriteRenderer sRenderer;
	public BoxCollider2D box;
	//public int i;
	public bool change;


	void Start(){
		sRenderer = GetComponent<SpriteRenderer> ();
		box = GetComponent<BoxCollider2D> ();
		change = true;
		}

	void OnTriggerExit2D(Collider2D col){
		if (change) {
		GameManager.instance.i++;
			change = false;
			camera.transform.position = GameManager.instance.posArray [GameManager.instance.i];

		}
		else {
		GameManager.instance.i--;
		change = true;
		camera.transform.position = GameManager.instance.posArray [GameManager.instance.i];
		}
	}
}
