using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int i;

	public Vector3[] posArray;
	
	void Awake(){
				instance = this;


				posArray [0] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [1] = new Vector3 (20.8f, 0f, -20.3f);
				posArray [2] = new Vector3 (41.3f, 0f, -20.3f);
				posArray [3] = new Vector3 (61.8f, 0f, -20.3f);
				posArray [4] = new Vector3 (82.3f, 0f, -20.3f);
				posArray [5] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [6] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [7] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [8] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [9] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [10] = new Vector3 (0.3f, 0f, -20.3f);
				posArray [11] = new Vector3 (0.3f, 0f, -20.3f);
		}
	// Use this for initialization
	void Start () {
		i = 0;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
